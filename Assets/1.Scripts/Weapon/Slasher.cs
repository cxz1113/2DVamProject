using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slasher : Weapon
{
    public override void Initialize()
    {
        bulletPos = transform.GetChild(0).transform;
        weaponDataType = WeaponDataType.Slasher;
        wd.player = GameControllerManager.instance.player;
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
            if(!wd.player.IsLevel)
                BulletCreate();
        }

        /*if (wd.player.pd.enemy != null && wd.player.pd.enemy.IsAlive)
        {
            // 몬스터 방향으로 Bullet 회전
            Vector2 vec = transform.position - wd.player.pd.enemy.transform.position;
            float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
            bulletPos.rotation = rotation;
        }*/
    }

    public void BulletCreate()
    {
        if (wd.player.pd.enemy != null)
        {
            Vector2 vec = transform.position - wd.player.pd.enemy.transform.position;
            float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
            bulletPos.rotation = rotation;

            Bullet bullet = Instantiate(this.bullet, bulletPos);
            bullet.transform.SetParent(wd.player.parent);
            Destroy(bullet.gameObject, 2f);
        }
    }
}   
