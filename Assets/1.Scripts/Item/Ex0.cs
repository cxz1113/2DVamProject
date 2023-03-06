using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex0 : Item
{
    public override void Initialize()
    {
        id.score = 50;
        ItemType = ItemType.Ex0;
        id.obj = gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }
}
