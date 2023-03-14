using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBullet : Bullet
{
    public override void Initialize()
    {
        bd.attack = 50;
        bd.speed = 6f;
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
