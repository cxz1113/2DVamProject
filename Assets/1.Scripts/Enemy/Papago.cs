using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Papago : Enemy
{
    public override void Initialize()
    {
        ed.hp = 100;
        ed.speed = 2.5f;
        ed.attack = 5f;
        ed.player = FindAnyObjectByType<Player>();
    }
}
