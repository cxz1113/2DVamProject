using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Enemy
{    public override void Initialize()
    {
        ed.maxHp = 200;
        ed.curHp = ed.maxHp;
        ed.speed = 4f;
        ed.attack = 20f;

        base.Initialize();
    }
}
