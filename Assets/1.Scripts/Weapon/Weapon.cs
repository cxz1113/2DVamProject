using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct WeaponData
{
    public float attack;
    public float speed;
}

public enum WeaponDataType
{
    Shovel,
    Spear,
    Slasher,
    Gun,
    Rifle,
    ShotGun
}
public abstract class Weapon : MonoBehaviour
{
    public WeaponData wd = new WeaponData();
    public WeaponDataType weaponDataType;
    public Sprite weaponSprite;

    public abstract void Initialize();
    
    public virtual void Move()
    {
        transform.Translate(Vector2.up * Time.deltaTime * wd.speed);
    }

    void Update()
    {
        Move();
    }
}
