using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeShovel : MeleeWeapon
{
    public override void Initialize()
    {
        md.attack = 15;
        md.player = GameControllerManager.instance.player;
    }

    void Start()
    {
        Initialize();
        transform.localPosition = Vector2.zero;
    }
}
