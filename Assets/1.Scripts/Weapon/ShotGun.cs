using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Weapon
{
    public List<Transform> fireTrans;
    public Transform rotate;
    int[] angleT = { 60, 75, 90, 105, 120 };

    public override void Initialize()
    {
        bulletPos = transform.GetChild(0).transform;
        wd.player = GameControllerManager.instance.player;
        weaponDataType = WeaponDataType.ShotGun;
    }

    void Start()
    {
        Initialize();
    }

    void Update()
    {
        //Flip();
        wd.fireTime += Time.deltaTime;
        if (wd.fireTime > 1f)
        {
            wd.fireTime = 0;
            FireTrans();
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

    void FireTrans()
    {
        int randt = Random.Range(0, angleT.Length);
        if(wd.player.pd.enemy != null)
        {
            if (fireTrans.Count < 5)
            {
                foreach (var angleRo in angleT)
                {
                    Vector2 vec = transform.position - wd.player.pd.enemy.transform.position;
                    float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
                    Quaternion rotation = Quaternion.AngleAxis(angle + angleRo, Vector3.forward);
                    rotate.rotation = rotation;
                    fireTrans.Add(rotate);
                }
            }

            foreach(var fire in fireTrans)
            {
                Bullet bullet = Instantiate(this.bullet, fire);
                bullet.transform.SetParent(wd.player.parent);
                Destroy(bullet.gameObject, 1f);
            }
        }
    }

    void FirTransRo()
    {
        int randt = Random.Range(0, angleT.Length);
        if(wd.player.pd.enemy != null)
        {
            for (int i = 0; i < 5; i++)
            {
                Vector2 vec = transform.position - wd.player.pd.enemy.transform.position;
                float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.AngleAxis(angle + angleT[randt], Vector3.forward);
                //fireTrans[randFire].rotation = rotation;

                Bullet bullet = Instantiate(this.bullet, fireTrans[i]);
                bullet.transform.SetParent(wd.player.parent);
                Destroy(bullet.gameObject, 1f);
            }
        }        
    }
}
