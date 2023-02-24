using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    public override void Initialize()
    {
        ed.hp = 100;
        ed.speed = 3f;
        ed.attack = 7.5f;
        ed.player = FindAnyObjectByType<Player>();
    }
}
