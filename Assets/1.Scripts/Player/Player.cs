using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerData
{
    public float hp;
    public float speed;
    public float attack;
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
    Enemy enemy;
    public abstract void Initialize();

    public float HP
    {
        get { return pd.hp; }
        set { pd.hp = value; }
    }

    float fireTime = 0;

    void Start()
    {
    }
    void Update()
    {
        Move();
        if(HP <= 0)
        {
            Die();
        }
        FindEnemy();
    }
    public void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        
        Vector3 dir = new Vector3(x, y, 0f);
        transform.Translate(dir * Time.deltaTime * pd.speed);

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
        fireTime += Time.deltaTime;
        if(fireTime > 1f)
        {
            fireTime = 0;
            BulletCreat();
        }
    }

    void FindEnemy()
    {
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
            Vector2 vec = transform.position - enemy.transform.position;
            float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
            //bulletPos.rotation = rotation;
            Weapon wp = Instantiate(weapon, bulletPos.position, Quaternion.AngleAxis(angle + 90, Vector3.forward));
            wp.transform.SetParent(parent);
            wp.Initialize();
        }              
    }
    void Die()
    {
        GetComponent<SpriteAnimation>().SetSprite(dieSp, 0.2f);
    }
}
