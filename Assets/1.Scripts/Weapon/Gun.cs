using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    public override void Initialize()
    {
        wd.attack = 50;
        wd.speed = 6f;
        weaponDataType = WeaponDataType.Gun;
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
            BulletCreate();
        }

        if (wd.player != null)
        {
            if (wd.player.pd.enemy != null)
            {
                // 몬스터 방향으로 Bullet 회전
                Vector2 vec = transform.position - wd.player.pd.enemy.transform.position;
                float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
                bulletPos.rotation = rotation;
            }
        }
    }

    public void BulletCreate()
    {
        if (wd.player != null && wd.player.pd.enemy != null)
        {
            Bullet bullet = Instantiate(this.bullet, bulletPos);
            bullet.transform.SetParent(wd.player.parent);
            Destroy(bullet.gameObject, 5f);
        }
    }
}
