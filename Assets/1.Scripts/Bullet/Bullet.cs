using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct BulletData
{
    public float attack;
    public float speed;
    public float fireTime;
    public Player player;
    public Enemy enemy;
}
public abstract class Bullet : MonoBehaviour
{
    public BulletData bd = new BulletData();
    [HideInInspector] public GameObject move;
    public abstract void Initialize();

    public virtual void Move()
    {
        transform.Translate(Vector2.up * Time.deltaTime * bd.speed);
    }
}
