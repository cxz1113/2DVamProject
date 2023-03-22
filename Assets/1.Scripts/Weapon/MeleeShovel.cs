using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeShovel : Weapon
{
    public override void Initialize()
    {
        wd.attack = 15;
        wd.player = GameControllerManager.instance.player;
    }

    void Start()
    {
        Initialize();
        transform.localPosition = Vector2.zero;
    }
}
