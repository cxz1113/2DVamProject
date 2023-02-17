using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMan : Player
{
    public override void Initialize()
    {
        pt.hp = 100;
        pt.speed = 4.5f;
        pt.attack = 5;
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
        base.Move();
    }
}
