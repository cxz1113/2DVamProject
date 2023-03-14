using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct WeaponData
{
    public float attack;
    public float speed;
    public float fireTime;
    public Enemy enemy;
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
    public Sprite weaponSprite;

    public abstract void Initialize();

    public abstract void Move();

    public virtual void BulletCreate()
    {
        // 몬스터 방향으로 Bullet 회전
        Vector2 vec = wd.player.transform.position - wd.enemy.transform.position;
        float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        wd.player.bulletPos.rotation = rotation;

        Weapon wp = Instantiate(wd.player.weapon, wd.player.bulletPos.position, Quaternion.AngleAxis(angle + 90, Vector3.forward));
        //Weapon wp = Instantiate(weapon, bulletPos.transform);
        wp.transform.SetParent(wd.player.parent);
        wp.Move();
        Destroy(wp.gameObject, 5f);        
    }
}
