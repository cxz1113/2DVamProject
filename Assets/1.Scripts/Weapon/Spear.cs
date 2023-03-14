using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : Weapon
{
    public override void Initialize()
    {
        wd.attack = 20;
        wd.speed = 4f;
        weaponDataType = WeaponDataType.Spear;
    }

    void Start()
    {
        Initialize();
    }

    void Update()
    {
        Move();
    }
    public override void Move()
    {
        transform.Translate(Vector2.up * Time.deltaTime * wd.speed);
    }
}
