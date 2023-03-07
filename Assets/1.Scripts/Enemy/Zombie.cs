using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{
    public override void Initialize()
    {
        ed.maxHp = 100;
        ed.curHp = ed.maxHp;
        ed.speed = 2f;
        ed.attack = 10f;
        ed.level = 1;
        ed.player = FindAnyObjectByType<Player>();
        IsAlive = true;
        ed.itemObj = items;

        base.Initialize();
    }
}
