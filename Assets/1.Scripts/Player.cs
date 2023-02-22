using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerType
{
    public int hp;
    public float speed;
    public float attack;
}
public enum Direction
{
    Stand,
    Left,
    Right,
    Up,
    Down
}

public abstract class Player : MonoBehaviour
{
    public PlayerType pt = new PlayerType();    

    public Direction direction = Direction.Stand;

    [SerializeField] public List<Sprite> idleSp;
    [SerializeField] private List<Sprite> moveSp;
    [SerializeField] private List<Sprite> dieSp;
    [SerializeField] private SpriteRenderer sr;

    public Vector3 vec;
    public abstract void Initialize();

    public virtual void Move()
    {
        vec.x = Input.GetAxisRaw("Horizontal");
        vec.y = Input.GetAxisRaw("Vertical");
        
        Vector3 dir = new Vector3(vec.x, vec.y, 0f);
        transform.Translate(dir * Time.deltaTime * pt.speed);

        if(vec.x < 0)
        {
            sr.flipX = true;
        }
        else if(vec.x > 0)
        {
            sr.flipX = false;
        }
        // 왼쪽 또는 오른쪽 이동시 Sprite 사용
        if(vec.x < 0 && direction != Direction.Left)
        {
            direction = Direction.Left;
            GetComponent<SpriteAnimation>().SetSprite(moveSp, 0.2f);
        }
        else if(vec.x > 0 && direction != Direction.Right)
        {
            direction = Direction.Right;
            GetComponent<SpriteAnimation>().SetSprite(moveSp, 0.2f);
        }
        // 위쪽 또는 아래쪽 이동시 Sprite 사용
        else if (vec.y != 0 && direction != Direction.Up)
        {
            direction = Direction.Up;
            GetComponent<SpriteAnimation>().SetSprite(moveSp, 0.2f);
        }
        // 캐릭터가 정지해있을때 Idle Sprite 사용
        else if (dir == Vector3.zero && direction != Direction.Stand)
        {
            direction = Direction.Stand;
            GetComponent<SpriteAnimation>().SetSprite(idleSp, 0.2f);            
        }     
    }
}
