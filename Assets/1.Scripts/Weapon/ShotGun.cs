using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Weapon
{
    public override void Initialize()
    {
        wd.attack = 20;
        wd.speed = 4f;
        weaponDataType = WeaponDataType.Slasher;
    }

    void Start()
    {
        Initialize();
    }
    void Update()
    {
        wd.fireTime += Time.deltaTime;
        if (wd.fireTime > 1f)
        {
            wd.fireTime = 0;
        }
    }
}
