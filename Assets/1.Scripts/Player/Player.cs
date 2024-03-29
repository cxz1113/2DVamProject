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
    public Weapon weapon;
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
    public static Player Instance;

    [SerializeField] public List<Sprite> idleSp;
    [SerializeField] private List<Sprite> moveSp;
    [SerializeField] private List<Sprite> dieSp;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Image hpImage;

    public TMP_Text levelTxt;
    public Image exImage;
    public Weapon weapon;
    public List<Weapon> weapons;
    public Transform parent;
    public Transform hand;
    public List<Transform> meleeHands;
    public Transform melee;
    public PlayerData pd = new PlayerData();    
    public Direction direction = Direction.Stand;
    public Canvas hpCanvas;
    
    public bool IsAlive { get; set; }
    public bool IsHide { get; set; }
    public bool IsLevel { get; set; }
    public float HP
    {
        get { return pd.curHp; }
        set
        {
            pd.curHp = value;
            hpImage.fillAmount = pd.curHp / pd.maxHp;
            if (HP <= 0 && IsAlive)
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
            if (pd.curExperience >= pd.maxExperience)
            {
                LevelUp();
                pd.curHp = pd.maxHp;
            }
        }
    }

    public abstract void Initialize();

    void Update()
    {
        if (!IsAlive)
            return;

        levelTxt.text = string.Format("Lv.{0}", pd.level);

        Move();
        FindEnemy();

        melee.Rotate(Vector3.forward * Time.deltaTime * 150);

        if (Input.GetKeyDown(KeyCode.F1))
        {
            GameControllerManager.instance.uiCont.gameObject.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.F2))
        {
            GameControllerManager.instance.uiCont.gameObject.SetActive(false);
        }

    }

    public void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(x, y, 0f);
        transform.Translate(dir * Time.deltaTime * pd.speed);

        if (IsLevel)
            return;

        // FlipX를 이용하여 좌우반전
        if(x < 0)
        {
            pd.weapon.GetComponent<SpriteRenderer>().flipX = sr.flipX = true;
            pd.weapon.transform.GetChild(0).transform.localPosition = new Vector2(-0.7f, 0.09f);
        }
        else if(x > 0)
        {
            pd.weapon.GetComponent<SpriteRenderer>().flipX = sr.flipX = false;
            pd.weapon.transform.GetChild(0).transform.localPosition = new Vector2(0.7f, 0.09f);
        }

        // 왼쪽 또는 오른쪽 이동시 Sprite 사용
        if ((x != 0 || y != 0) && direction != Direction.Run)
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
            if (distance < dis)
            {
                pd.enemy = target;
                dis = distance;
            }
        }
    }

    void LevelUp()
    {
        pd.curExperience = 0;
        pd.maxHp += ((pd.level + (pd.level + 1)) * 25) - 25;
        pd.maxExperience += ((pd.level * (pd.level + 1)) * 25) - 50;
        pd.attack += ((pd.level * (pd.level + 1)) * 10) / 100;
        pd.speed += ((pd.level * (pd.level + 1)) * 0.5f) / 100;
        exImage.fillAmount = 0;
        pd.level++;
        if((pd.level % 5) == 0)
        {
            IsLevel = true;
            GameControllerManager.instance.uiCont.gameObject.SetActive(true);
        }
    }

    public IEnumerator ReLife()
    {
        bool show = false;
        for(int i = 0; i < 10; i++)
        {
            GetComponent<SpriteRenderer>().enabled = !show;
            pd.weapon.GetComponent<SpriteRenderer>().enabled = !show;
            show = !show;
            yield return new WaitForSeconds(0.2f);
        }
        hpCanvas.gameObject.SetActive(false);
        GetComponent<SpriteRenderer>().enabled = true;
        pd.weapon.GetComponent<SpriteRenderer>().enabled = true;
    }

    void Die()
    {
        if(!IsAlive)
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
            GetComponent<SpriteAnimation>().SetSprite(dieSp, 0.2f);
            hand.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
        }
    }

    public IEnumerator Hide()
    {
        IsHide = true;
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.2f);
        pd.weapon.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.2f);

        yield return new WaitForSeconds(3f);

        IsHide = false;
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        pd.weapon.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }

    public void MeleeRotate()
    {
        /*if(Input.GetKeyDown(KeyCode.F7))
        {
            testCnt++;

            if(testCnt >= meleeHands.Count - 1)
            {
                testCnt = meleeHands.Count - 1;
            }

            foreach(var item in meleeHands)
            {
                item.gameObject.SetActive(false);
            }

            int val = 360 / testCnt;
            int tempVal = val;
            for (int i = 0; i < testCnt; i++)
            {
                meleeHands[i].gameObject.SetActive(true);
                meleeHands[i].rotation = Quaternion.Euler(new Vector3(0f, 0f, tempVal));
                tempVal += val;
            }

            melee.transform.rotation = Quaternion.Euler(Vector3.zero);
        }

        if(testCnt > 0)
            melee.transform.Rotate(Vector3.forward * Time.deltaTime * 150);*/
    }

    public void MPosition()
    {
        int[] radian = { 60, 120, 180, 240, 300, 360 };
        int[] radianP = { -30, 30, 90, 150, -150, -90 };

        for (int i = 0; i < 6; i++)
        {
            meleeHands[i].position = new Vector3(Mathf.Cos(radian[i] * Mathf.Deg2Rad), Mathf.Sin((radian[i]) * Mathf.Deg2Rad));
            /*Vector2 vec = transform.position - meleeHands[i].transform.position;
            float angle = Mathf.Atan2(vec.x, vec.y) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(360/ angle , Vector3.forward);*/

            meleeHands[i].rotation = Quaternion.Euler(0, 0, radianP[i]);
        }
    }
}
