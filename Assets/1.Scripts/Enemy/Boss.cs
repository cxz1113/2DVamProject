using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public override void Initialize()
    {
        ed.maxHp = 500;
        ed.curHp = ed.maxHp;
        ed.speed = 4f;
        ed.attack = 20f;

        transform.localScale = new Vector3(3, 3, 1);
        base.Initialize();
    }
}
