using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlasherBullet : Bullet
{
    public override void Initialize()
    {
        bd.attack = 20;
        bd.speed = 6f;
        bd.fireTime = 0;
        bd.player = GameControllerManager.instance.player;
        move = transform.GetChild(0).gameObject;
    }

    void Start()
    {
        Initialize();
        move.GetComponent<SpriteRenderer>().sprite = transform.GetComponent<SpriteRenderer>().sprite;
        transform.GetComponent<SpriteRenderer>().sprite = null;
    }

    void Update()
    {

        Move();
    }

    public override void Move()
    {
        transform.Translate(Vector2.up * Time.deltaTime * bd.speed);
        move.transform.Rotate(0f, 0f, 20); 
    }
}
