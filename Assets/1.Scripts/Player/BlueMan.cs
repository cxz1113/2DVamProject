using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMan : Player
{
    public override void Initialize()
    {
        pd.hp = 100;
        pd.speed = 4.5f;
        pd.attack = 5;
    }

    void Start()
    {
        Initialize();
        direction = Direction.Stand;
        GetComponent<SpriteAnimation>().SetSprite(idleSp, 0.2f);
    }
}
