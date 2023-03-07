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
    public int level;
    public Player player;
    public EnemyState state;
    public GameObject[] itemObj;
}

public abstract class Enemy : MonoBehaviour
{
    public EnemyData ed = new EnemyData();

    [SerializeField] private List<Sprite> moveSp;
    [SerializeField] private List<Sprite> hitSp;
    [SerializeField] private List<Sprite> dieSp;
    [SerializeField] private Image hpImage;
    public GameObject[] items;

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
                Die();
            }
        }
    }
    public virtual void Initialize()
    {
        if (ed.player.pd.level % 5 == 0)
        {
            if (ed.level >= 5)
                return;
            ed.level++;
            ed.maxHp += ((ed.level + (ed.level + 1)) * 25) + 25;
            ed.attack += ((ed.level * (ed.level + 1)) * 10) / 100;
            ed.speed += ((ed.level * (ed.level + 1)) * 0.5f) / 100;
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

    public void ItemDrop(GameObject[] items, Transform trans)
    {
        int rand = Random.Range(0, 101);
        if (rand > 33)
        {
            Instantiate(items[0], trans).transform.SetParent(trans);
        }
        else
        {
            Instantiate(items[Random.Range(1, items.Length)], trans).transform.SetParent(trans);
        }        
    }

    Stack<Vector2> moveSaving = new Stack<Vector2>();
    float moveSaveTime = 0;
    public void Move()
    {
        if (ed.player.IsHide || !ed.player.IsAlive)
            return;

        Vector3 distance = ed.player.transform.position - transform.position;
        if(ed.player.IsAlive)
        {
            if(IsAlive)
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
            else if (ed.state != EnemyState.Dead)
            {
                ed.state = EnemyState.Dead;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            HP -= collision.gameObject.GetComponent<Weapon>().wd.attack;            
            if (IsAlive)
                GetComponent<SpriteAnimation>().SetSprite(hitSp[0], moveSp, 0.2f);
            StopCoroutine("BackMove");
            StartCoroutine("BackMove");
            Destroy(collision.gameObject);
        }
        else if(collision.CompareTag("player"))
        {
            Player player = collision.GetComponent<Player>();
            player.hpCanvas.gameObject.SetActive(true);
            player.HP -= ed.attack;
            if (player.IsAlive)
                StartCoroutine(player.ReLife());
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
        if (!IsAlive)
        {
            ItemDrop(items, transform);
            transform.GetChild(0).gameObject.SetActive(false);
            GetComponent<CapsuleCollider2D>().enabled = false;
            Destroy(GetComponent<Rigidbody2D>());
            GetComponent<SpriteAnimation>().SetSprite(dieSp[0], 0.2f, 0.5f);
        }
    }
}
