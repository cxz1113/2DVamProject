using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct WeaponData
{
    public float attack;
    public float speed;
    public float fireTime;
    public Player player;
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
    public Sprite seletSprite;
    public Bullet bullet;
    public Transform bulletPos;

    public abstract void Initialize();
}
