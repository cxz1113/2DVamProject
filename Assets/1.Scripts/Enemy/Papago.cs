using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Papago : Enemy
{
    public override void Initialize()
    {
        ed.hp = 100;
        ed.speed = 3f;
        ed.attack = 5f;
        ed.player = FindAnyObjectByType<Player>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

}
