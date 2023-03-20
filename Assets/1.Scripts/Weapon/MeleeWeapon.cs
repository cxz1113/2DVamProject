using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MeleeWeaponData
{
    public float speed;
    public float attack;
    public Player player;
}
public abstract class MeleeWeapon : MonoBehaviour
{
    public List<MeleeWeapon> meleeWeapons;
    public MeleeWeaponData md = new MeleeWeaponData();

    public abstract void Initialize();

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.RotateAround(GameControllerManager.instance.player.transform.position, Vector3.forward, Time.deltaTime * 150);
    }
}
