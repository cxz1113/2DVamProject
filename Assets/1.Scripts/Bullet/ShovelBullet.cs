using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelBullet : Bullet
{
    public override void Initialize()
    {
        bd.attack = 20;
        bd.speed = 4f;
        bd.fireTime = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    void Update()
    {
        Move();
    }

    public override void Move()
    {
        transform.Translate(Vector2.up * Time.deltaTime * bd.speed);
    }
}
