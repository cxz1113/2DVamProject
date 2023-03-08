using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : Item
{
    public override void Initialize()
    {
        id.attack = 2;
        ItemType = ItemType.Attack;
        id.obj = gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }
}
