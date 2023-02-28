using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : Weapon
{
    public override void Initialize()
    {
        wd.attack = 5;
        wd.speed = 10f;
        weaponDataType = WeaponDataType.Shovel;
    }

}
