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
    public WeaponDataType weaponDataType = WeaponDataType.Shovel;

    float deleteTime = 0;
    public abstract void Initialize();

    public virtual void Move()
    {
        transform.Translate(Vector2.up * Time.deltaTime * wd.speed);
    }
    
    void Update()
    {
        Move();
        deleteTime += Time.deltaTime;
        if(deleteTime > 5)
        {
            deleteTime = 0;
            Destroy(gameObject);
        }
    }
}
