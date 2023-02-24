using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    public override void Initialize()
    {
        wd.attack = 5;
        wd.speed = 1.5f;
        weaponDataType = WeaponDataType.Gun;
    }

    void Start()
    {
        Initialize();
    }
}
