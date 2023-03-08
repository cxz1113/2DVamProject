using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : Item
{
    public override void Initialize()
    {
        id.speed = 1;
        ItemType = ItemType.Speed;
        id.obj = gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }
}
