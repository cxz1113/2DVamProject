using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Idle,
    Run,
    Hit,
    Dead
}

public struct EnemyData
{
    public int hp;
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

    float attDelay = 0;

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
            else
            {
                Damage();
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

    public void Damage()
    {

        attDelay += Time.deltaTime;
        if(attDelay > 0.5f)
        {
            attDelay = 0;
            ed.state = EnemyState.Hit;
            GetComponent<SpriteAnimation>().SetSprite(hitSp);
            ed.player.GetComponent<Player>().HP -= ed.attack;
        }
    }
}
