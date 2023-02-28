using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : Weapon
{
    public override void Initialize()
    {
        wd.attack = 20;
        wd.speed = 3f;
        weaponDataType = WeaponDataType.Shovel;
    }

}
