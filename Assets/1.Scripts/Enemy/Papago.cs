using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Papago : Enemy
{
    public override void Initialize()
    {
        ed.maxHp = 100;
        ed.curHp = ed.maxHp;
        ed.speed = 2.5f;
        ed.attack = 5f;

        base.Initialize();
    }
}
