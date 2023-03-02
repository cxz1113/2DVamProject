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
    public Player player;
    public EnemyState state;
}
public abstract class Enemy : MonoBehaviour
{
    public EnemyData ed = new EnemyData();

    public abstract void Initialize();

    [SerializeField] private List<Sprite> moveSp;
    [SerializeField] private Sprite hitSp;
    [SerializeField] private Sprite dieSp;
    [SerializeField] private Image hpImage;

    float attDelay = 0;
    float dieDelay = 0;

    public bool IsAlive { get; set; }
    public float HP
    {
        get { return ed.curHp; }
        set
        {
            ed.curHp = value;
            hpImage.fillAmount = ed.curHp / ed.maxHp;            
        }
    }

    void Update()
    {
        Move();
        if(HP <= 0)
        {
            IsAlive = false;
            Die();
        }
    }

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
            else if(dis < 1.5f)
            {
                attack();
            }           
            
            else if(!IsAlive && ed.state != EnemyState.Dead)
            {
                ed.state = EnemyState.Dead;
                transform.position = new Vector2(transform.position.x, transform.position.y);
            }
        }    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {            
            GetComponent<SpriteAnimation>().SetSprite(hitSp, moveSp, 0.2f);
            HP -= collision.gameObject.GetComponent<Weapon>().wd.attack;
        }
    }

    public void attack()
    {
        attDelay += Time.deltaTime;
        if(attDelay > 0.5f)
        {
            attDelay = 0;
            ed.player.GetComponent<Player>().HP -= ed.attack;
        }
    }
    public void Die()
    {
        if(!IsAlive)
        {
            GetComponent<CapsuleCollider2D>().isTrigger = true;
            GetComponent<Rigidbody2D>().position = new Vector2(transform.position.x, transform.position.y);
            GetComponent<SpriteRenderer>().sprite = dieSp;
            dieDelay += Time.deltaTime;
            if (dieDelay > 3)
            {
                Destroy(gameObject);
            }
        }        
    }
}
