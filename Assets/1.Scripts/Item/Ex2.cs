using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex2 : Item
{
    public override void Initialize()
    {
        id.score = 100;
        ItemType = ItemType.Ex2;
        id.obj = gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }
}