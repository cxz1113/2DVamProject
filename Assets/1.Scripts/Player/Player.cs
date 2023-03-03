using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public struct PlayerData
{
    public float maxHp;
    public float curHp;
    public float speed;
    public float attack;
    public int level;
    public float maxExperience;
    public float curExperience;
    public Enemy enemy;
}
public enum Direction
{
    Stand,
    Run,
    Die
}

public abstract class Player : MonoBehaviour
{
    public PlayerData pd = new PlayerData();    

    public Direction direction = Direction.Stand;

    [SerializeField] public List<Sprite> idleSp;
    [SerializeField] private List<Sprite> moveSp;
    [SerializeField] private List<Sprite> dieSp;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Weapon weapon;
    [SerializeField] private Transform parent;
    [SerializeField] private Transform bulletPos;
    [SerializeField] private Image exImage;
    [SerializeField] private TMP_Text levelTxt;
    [SerializeField] private Image hpImage;
    [SerializeField] private Canvas hpCanvas;
    Enemy enemy;
    public abstract void Initialize();

    public float HP
    {
        get { return pd.curHp; }
        set 
        { 
            pd.curHp = value;            
            hpImage.fillAmount = pd.curHp / pd.maxHp;
            if(HP <= 0 && IsAlive)
            {
                IsAlive = false;
                Die();
            }
        }
    }

    public float CurExperience
    {
        get { return pd.curExperience; }
        set
        {
            pd.curExperience = value;
            exImage.fillAmount = pd.curExperience / pd.maxExperience;
            if(pd.curExperience >= pd.maxExperience)
            {
                pd.level++;
                pd.curExperience = 0;
                pd.maxExperience += ((pd.level * (pd.level + 1)) * 25) - 50;                
            }
            Debug.Log(pd.maxExperience);
        }
    }
    
    public bool IsAlive { get; set; }
    float fireTime = 0;

    void Start()
    {
    }
    void Update()
    {
        if (!IsAlive)
            return;

        levelTxt.text = string.Format("Lv.{0}", pd.level);

        Move();
        FindEnemy();

        fireTime += Time.deltaTime;
        if (fireTime > 1f)
        {
            fireTime = 0;
            BulletCreat();
        }
    }
    public void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        
        Vector3 dir = new Vector3(x, y, 0f);
        transform.Translate(dir * Time.deltaTime * pd.speed);

        // FlipX를 이용하여 좌우반전
        if(x < 0)
        {
            sr.flipX = true;
        }
        else if(x > 0)
        {
            sr.flipX = false;
        }
        // 왼쪽 또는 오른쪽 이동시 Sprite 사용
        if((x != 0 || y != 0) && direction != Direction.Run)
        {
            direction = Direction.Run;
            GetComponent<SpriteAnimation>().SetSprite(moveSp, 0.2f);
        }
        // 캐릭터가 정지해있을때 Idle Sprite 사용
        else if (x == 0 && y == 0 && direction != Direction.Stand)
        {
            direction = Direction.Stand;
            GetComponent<SpriteAnimation>().SetSprite(idleSp, 0.2f);
        }
    }

    void FindEnemy()
    {
        // 적 찾기
        Enemy[] targets = FindObjectsOfType<Enemy>();

        if (targets.Length == 0)
            return;
        float dis = Vector3.Distance(transform.position, targets[0].transform.position);
        foreach (var target in targets)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);
            if(distance < dis)
            {
                enemy = target;
                dis = distance;
            }
        }      
    }
    void BulletCreat()
    {
        if (enemy != null)
        {  
            // 몬스터 방향으로 Bullet 회전
            Vector2 vec = transform.position - enemy.transform.position;
            float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
            bulletPos.rotation = rotation;

            //Weapon wp = Instantiate(weapon, bulletPos.position, Quaternion.AngleAxis(angle + 90, Vector3.forward));
            Weapon wp = Instantiate(weapon, bulletPos.transform);
            wp.transform.SetParent(parent);
            wp.Initialize();
            Destroy(wp.gameObject, 5f);
        }              
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if(collision.CompareTag("Enemy"))
        {            
            hpCanvas.GetComponent<Canvas>().enabled = true;
            HP -= collision.GetComponent<Enemy>().ed.attack;
        }        
    }

    IEnumerator ReLife()
    {
        bool show = false;
        for(int i = 0; i < 5; i++)
        {
            GetComponent<Image>().color = new Color(255, 255, 255, 150 / 255f);
            show = !show;
            yield return new WaitForSeconds(0.2f);
        }
        hpCanvas.GetComponent<Canvas>().enabled = false;        
    }
    void Die()
    {
        if(!IsAlive)
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
            GetComponent<SpriteAnimation>().SetSprite(dieSp, 0.2f);
        }
    }
}
