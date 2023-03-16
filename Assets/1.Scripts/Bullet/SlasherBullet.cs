using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlasherBullet : Bullet
{
    public override void Initialize()
    {
        bd.attack = 20;
        bd.speed = 6f;
        bd.fireTime = 0;
    }

    void Start()
    {
        Initialize();
    }

    void Update()
    {
        //Move();
        Test();
    }

    public override void Move()
    {
        transform.Translate(Vector2.up * Time.deltaTime * bd.speed);
        transform.rotation = Quaternion.Euler(0f, 0f, 15);
    }

    void Test()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, 4f);
    }
}
