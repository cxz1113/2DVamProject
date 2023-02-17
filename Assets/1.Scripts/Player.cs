using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerType
{
    public int hp;
    public float speed;
    public float attack;
}

public abstract class Player : MonoBehaviour
{
    public PlayerType pt = new PlayerType();

    public enum Direction
    {
        stop,
        left,
        right
    }

    private Direction ani = Direction.stop;

    [SerializeField] private List<Sprite> idleSp;
    [SerializeField] private List<Sprite> moveSp;
    [SerializeField] private List<Sprite> dieSp;

    SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        ani = Direction.stop;
    }

    public abstract void Initialize();

    public virtual void Move()
    {
        float x = Input.GetAxis("Horizontal");

        float y = Input.GetAxis("Vertical");
        
        Vector2 dir = new Vector3(x , y);
        transform.Translate(dir * Time.deltaTime * pt.speed);

        if(x == 0 && y == 0)
        {
            ani = Direction.stop;
            GetComponent<SpriteAnimation>().SetSprite(idleSp, 0.2f);
        }
        else if(x > 0)
        {
            GetComponent<SpriteAnimation>().SetSprite(moveSp, 0.2f);            
        }
        else if(x < 0)
        {
            sr.flipX = true;
            GetComponent<SpriteAnimation>().SetSprite(moveSp, 0.2f);
        }
    }
}
