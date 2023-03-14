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

    public abstract void Initialize();

    public abstract void Move();
}
