using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    public override void Initialize()
    {
        wd.attack = 50;
        wd.speed = 6f;
        weaponDataType = WeaponDataType.Gun;
    }

    void Start()
    {
        Initialize();
    }
}
