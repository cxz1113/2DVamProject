using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    public override void Initialize()
    {
        ed.maxHp = 100;
        ed.curHp = ed.maxHp;
        ed.speed = 3f;
        ed.attack = 7.5f;
        ed.level = 1;
        ed.player = FindAnyObjectByType<Player>();
        IsAlive = true;

        base.Initialize();
    }
}
