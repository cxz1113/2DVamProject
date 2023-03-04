using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EnemyState
{
    Idle,
    Run,
    Hit,
    Dead
}

public struct EnemyData
{
    public float maxHp;
    public float curHp;
    public float speed;
    public float attack;
    public float score;
    public int level;
    public Player player;
    public EnemyState state;
}

public enum EdLevelSystem
{
    None,
    MaxHp,
    Speed,
    Attack
}

public abstract class Enemy : MonoBehaviour
{
    public EnemyData ed = new EnemyData();
    public EdLevelSystem edlv = EdLevelSystem.None;
    public abstract void Initialize();

    [SerializeField] private List<Sprite> moveSp;
    [SerializeField] private List<Sprite> hitSp;
    [SerializeField] private List<Sprite> dieSp;
    [SerializeField] private Image hpImage;

    public bool IsAlive { get; set; }
    public float HP
    {
        get { return ed.curHp; }
        set
        {            
            ed.curHp = value;
            hpImage.fillAmount = ed.curHp / ed.maxHp;   
            if(ed.curHp <= 0)
            {
                IsAlive = false;
                ed.player.CurExperience += ed.score;
                Die();
            }
        }
    }

    void Update()
    {
        if (!IsAlive)
            return;

        moveSaveTime += Time.deltaTime;
        if (moveSaveTime > 0.1f)
        {
            moveSaving.Push(transform.position);
            moveSaveTime = 0;
        }
        Move();
    }

    Stack<Vector2> moveSaving = new Stack<Vector2>();
    float moveSaveTime = 0;
    public void Move()
    {
        Vector3 distance = ed.player.transform.position - transform.position;
        float dis = Vector3.Distance(transform.position, ed.player.transform.position);

        if (ed.player != null)
        {
            if(IsAlive && dis > 1f)
            {
                transform.Translate(Time.deltaTime * ed.speed * distance.normalized);
                if (distance.normalized.x < 0)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                else
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                }
                if (ed.state != EnemyState.Run)
                {
                    ed.state = EnemyState.Run;
                    GetComponent<SpriteAnimation>().SetSprite(moveSp, 0.2f);
                }
            }       
            
            else if(!IsAlive && ed.state != EnemyState.Dead)
            {
                ed.state = EnemyState.Dead;
                transform.position = new Vector2(transform.position.x, transform.position.y);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.CompareTag("Bullet"))
        {
            GetComponent<SpriteAnimation>().SetSprite(hitSp[0], moveSp, 0.2f);
            HP -= collision.gameObject.GetComponent<Weapon>().wd.attack;
            Destroy(collision.gameObject);
            StopCoroutine("BackMove");
            StartCoroutine("BackMove");
        }
    }

    public void LevelUp()
    {               
        if(ed.player.pd.level % 5 == 0)
        {
            if (ed.level >= 5)
                return;
            ed.level++;
            ed.maxHp += ((ed.level + (ed.level + 1)) * 25) + 25;
            ed.attack += ((ed.level * (ed.level + 1)) * 10) / 100;
            ed.speed += ((ed.level * (ed.level + 1)) * 0.5f) / 100;
            Debug.Log(ed.level);
        }
        
    }
    IEnumerator BackMove()
    {
        int count = 2;
        while(true)
        {
            if (!IsAlive)
                break;
            yield return new WaitForSeconds(0.05f);
            if (count <= 0)
                break;

            if (moveSaving.Count == 0)
                break;

            transform.position = moveSaving.Pop();

            count--;
        }
        moveSaving.Clear();
    }

    public void Die()
    {
        if(!IsAlive)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            GetComponent<CapsuleCollider2D>().isTrigger = true;
            GetComponent<Rigidbody2D>().position = new Vector2(transform.position.x, transform.position.y);
            GetComponent<SpriteAnimation>().SetSprite(dieSp[0], dieSp, 0.2f);
            Destroy(gameObject, 2f);
        }        
    }
}
