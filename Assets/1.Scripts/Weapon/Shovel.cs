using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : Weapon
{
    public override void Initialize()
    {
        wd.attack = 20;
        wd.speed = 4f;
        wd.fireTime = 0;
        weaponDataType = WeaponDataType.Shovel;
    }

    void Start()
    {
        Initialize();
    }

    void Update()
    {
        wd.fireTime += Time.deltaTime;
        if(wd.fireTime > 1f)
        {
            wd.fireTime = 0;
            BulletCreate();
        }
    }
    public override void Move()
    {
        transform.Translate(Vector2.up * Time.deltaTime * wd.speed);
    }

    public override void BulletCreate()
    {
        base.BulletCreate();
    }
}
