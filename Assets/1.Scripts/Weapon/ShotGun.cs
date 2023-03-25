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
        wd.player = Player.Instance;
        weaponDataType = WeaponDataType.ShotGun;
    }

    void Start()
    {
        Initialize();
    }

    void Update()
    {
        wd.fireTime += Time.deltaTime;
        if (wd.fireTime > 3f)
        {
            wd.fireTime = 0;
            StartCoroutine("FireTrans");
        }
    }

    public void BulletCreate(List<Transform> trans)
    {
        foreach(var fire in trans)
        {
            Bullet bullet = Instantiate(this.bullet, fire);
            bullet.transform.SetParent(wd.player.parent);
            Destroy(bullet.gameObject, 2f);
        }
    }

    IEnumerator FireTrans()
    {
        if (wd.player.pd.enemy != null)
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

                    int rand = Random.Range(0, fireTrans.Count);
                    Bullet bullet = Instantiate(this.bullet, fireTrans[rand]);
                    bullet.transform.SetParent(wd.player.parent);
                    Destroy(bullet.gameObject, 1f);
                }
                fireTrans.Clear();
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
