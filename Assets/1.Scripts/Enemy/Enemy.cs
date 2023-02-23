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
        if(ed.player != null)
        {
            Vector3 distance = ed.player.transform.position - transform.position;
            
            transform.Translate(Time.deltaTime * ed.speed * distance.normalized);
            if(distance.normalized.x < 0)
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
}
