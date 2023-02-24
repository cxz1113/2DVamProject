using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerData
{
    public float hp;
    public float speed;
    public float attack;
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

    public abstract void Initialize();

    public float HP
    {
        get { return pd.hp; }
        set { pd.hp = value; }
    }
    void Update()
    {
        Move();
        if(HP <= 0)
        {
            Die();
        }
        Debug.Log(HP);
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
        // ���� �Ǵ� ������ �̵��� Sprite ���
        if((x != 0 || y != 0)&& direction != Direction.Run)
        {
            direction = Direction.Run;
            GetComponent<SpriteAnimation>().SetSprite(moveSp, 0.2f);
        }
        // ĳ���Ͱ� ������������ Idle Sprite ���
        else if (x == 0 && y == 0 && direction != Direction.Stand)
        {
            direction = Direction.Stand;
            GetComponent<SpriteAnimation>().SetSprite(idleSp, 0.2f);
        }        
    }

    void Die()
    {
        GetComponent<SpriteAnimation>().SetSprite(dieSp, 0.2f);
    }
}
