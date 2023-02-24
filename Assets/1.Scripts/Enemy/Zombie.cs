using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{
    public override void Initialize()
    {
        ed.hp = 100;
        ed.speed = 2f;
        ed.attack = 10f;
        ed.player = FindAnyObjectByType<Player>();
    }
}
