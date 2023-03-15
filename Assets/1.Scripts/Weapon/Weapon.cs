using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct WeaponData
{
    public float attack;
    public float speed;
    public float fireTime;
    public Enemy enemy;
    public Player p;
    public Bullet bullet;
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
    public Bullet bullet;
    public Transform bulletPos;

    public abstract void Initialize();
}
