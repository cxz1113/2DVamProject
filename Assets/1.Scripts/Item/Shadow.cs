using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : Item
{
    public override void Initialize()
    {
        ItemType = ItemType.Shadow;
        id.obj = gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }
}
