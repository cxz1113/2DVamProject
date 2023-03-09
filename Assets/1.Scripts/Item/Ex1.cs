using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex1 : Item
{
    public override void Initialize()
    {
        id.score = 75;
        ItemType = ItemType.Ex1;
        id.obj = gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }
}
