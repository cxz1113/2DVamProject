using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Weapon
{
    public override void Initialize()
    {
        bulletPos = transform.GetChild(0).transform;
        wd.player = GameControllerManager.instance.player;
        weaponDataType = WeaponDataType.Slasher;
    }

    void Start()
    {
        Initialize();
    }

    void Update()
    {
        Flip();
        wd.fireTime += Time.deltaTime;
        if (wd.fireTime > 1f)
        {
            wd.fireTime = 0;
            BulletCreate();
        }
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

    void Flip()
    {
        if(wd.player.weapon.GetComponent<SpriteRenderer>().flipX)
        {
            bulletPos.Translate(new Vector2(0.7f, 0.09f));
        }
        else
        {
            bulletPos.Translate(new Vector2(-0.7f, 0.09f));

        }
    }
}
