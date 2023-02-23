using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedWoman : Player
{
    public override void Initialize()
    {
        pt.hp = 50;
        pt.speed = 7f;
        pt.attack = 10f;
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        direction = Direction.Stand;
        GetComponent<SpriteAnimation>().SetSprite(idleSp, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public override void Move()
    {
        base.Move();
    }
}
