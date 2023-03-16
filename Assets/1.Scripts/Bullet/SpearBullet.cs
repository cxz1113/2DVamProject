using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearBullet : Bullet
{
    public override void Initialize()
    {
        bd.attack = 30;
        bd.speed = 10f;
        bd.fireTime = 0;
    }

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
