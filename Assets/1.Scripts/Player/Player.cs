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
    [SerializeField] private Transform parent;
    [SerializeField] private Weapon weapon;
    public abstract void Initialize();

    public float HP
    {
        get { return pd.hp; }
        set { pd.hp = value; }
    }
    void Start()
    {
        InvokeRepeating("BulletCreat", 2f, 0.3f);
    }
    void Update()
    {
        Move();
        if(HP <= 0)
        {
            Die();
        }
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
        // 왼쪽 또는 오른쪽 이동시 Sprite 사용
        if((x != 0 || y != 0)&& direction != Direction.Run)
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

    void BulletCreat()
    {
        Weapon wp = Instantiate(weapon, transform);
        wp.transform.SetParent(parent);
        wp.Initialize();
    }
    void Die()
    {
        GetComponent<SpriteAnimation>().SetSprite(dieSp, 0.2f);
    }
}
