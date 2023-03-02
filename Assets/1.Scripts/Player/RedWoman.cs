using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedWoman : Player
{
    public override void Initialize()
    {
        pd.hp = 50;
        pd.speed = 7f;
        pd.attack = 10f;
        IsAlive = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        direction = Direction.Stand;
        GetComponent<SpriteAnimation>().SetSprite(idleSp, 0.2f);
    }
}
