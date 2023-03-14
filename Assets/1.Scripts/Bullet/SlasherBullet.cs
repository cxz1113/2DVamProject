using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlasherBullet : Bullet
{
    public override void Initialize()
    {
        bd.attack = 20;
        bd.speed = 4f;
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
