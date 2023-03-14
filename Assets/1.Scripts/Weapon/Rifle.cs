using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Weapon
{
    public override void Initialize()
    {
        wd.attack = 20;
        wd.speed = 7f;
        weaponDataType = WeaponDataType.Rifle;
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
