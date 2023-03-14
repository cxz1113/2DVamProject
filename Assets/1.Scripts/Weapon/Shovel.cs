using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : Weapon
{
    public override void Initialize()
    {
        wd.attack = 20;
        wd.speed = 4f;
        wd.fireTime = 0;
        wd.bullet = bullet;
        wd.setParent = bulletPos;
        wd.player = GameControllerManager.instance.player;
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
    }
    public void BulletCreate()
    {
        // 몬스터 방향으로 Bullet 회전
        Vector2 vec = wd.player.transform.position - wd.enemy.transform.position;
        float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle + 360, Vector3.forward);
        GameControllerManager.instance.player.bulletPos.rotation = rotation;

        wd.bullet = Instantiate(wd.bullet, GameControllerManager.instance.player.bulletPos.position, Quaternion.AngleAxis(angle + 90, Vector3.forward));
        wd.bullet.transform.SetParent(GameControllerManager.instance.player.parent);
        wd.bullet.Initialize();
        Destroy(wd.bullet.gameObject, 5f);
    }
}
