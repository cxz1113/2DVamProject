using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : Weapon
{
    public override void Initialize()
    {
        bulletPos = transform.GetChild(0).transform;
        wd.attack = 20;
        wd.speed = 4f;
        wd.fireTime = 0;
        wd.bullet = bullet;
        wd.p = GameControllerManager.instance.player;
        wd.enemy = GameControllerManager.instance.enemy;
        weaponDataType = WeaponDataType.Shovel;
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
        if(wd.p != null)
        {
            if (wd.p.pd.enemy != null)
            {
                // 몬스터 방향으로 Bullet 회전
                Vector2 vec = transform.position - wd.p.pd.enemy.transform.position;
                float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
                bulletPos.rotation = rotation;
            }
        }
    }

    public void BulletCreate()
    {
        if (wd.p != null && wd.p.pd.enemy != null)
        {
            Bullet bullet = Instantiate(wd.bullet, bulletPos);
            bullet.transform.SetParent(wd.p.parent);
            bullet.Initialize();
            Destroy(bullet.gameObject, 5f);
        }
    }
}
