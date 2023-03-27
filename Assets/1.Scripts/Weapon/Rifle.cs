using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Weapon
{
    public override void Initialize()
    {
        bulletPos = transform.GetChild(0).transform;
        weaponDataType = WeaponDataType.Rifle;
        wd.player = Player.Instance;
    }

    void Start()
    {
        Initialize();
    }

    void Update()
    {
        wd.fireTime += Time.deltaTime;
        
        if(wd.fireTime > 2f)
        {
            wd.fireTime = 0;
            StartCoroutine(Fire());
        }        
    }

    IEnumerator Fire()
    {
        for(int i = 0; i < 4; i++)
        {
            if (wd.player.pd.enemy != null && wd.player.pd.enemy.IsAlive)
            {
                Vector2 vec = transform.position - wd.player.pd.enemy.transform.position;
                float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
                bulletPos.rotation = rotation;

                Bullet bullet = Instantiate(this.bullet, bulletPos);
                bullet.transform.SetParent(wd.player.parent);
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
