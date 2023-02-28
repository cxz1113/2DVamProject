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

    public float HP
    {
        get { return ed.curHp; }
        set
        {
            ed.curHp = value;
            hpImage.fillAmount = ed.curHp / ed.maxHp;
            if(ed.curHp <= 0)
            {

                GetComponent<SpriteRenderer>().sprite = dieSp;
                dieDelay += Time.deltaTime;
                if(dieDelay > 2)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    void Update()
    {
        Move(); 
    }

    public void Move()
    {
        Vector3 distance = ed.player.transform.position - transform.position;
        float dis = Vector3.Distance(transform.position, ed.player.transform.position);

        if (ed.player != null)
        {
            if(dis > 1f)
            {
                transform.Translate(Time.deltaTime * ed.speed * distance.normalized);            
            }
            else if(dis < 1.5f)
            {
                attack();
            }
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            GetComponent<SpriteAnimation>().SetSprite(hitSp, moveSp, 0.2f);            
            HP -= collision.GetComponent<Weapon>().wd.attack;            
        }
    }
    public void Damage()
    {

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
}
