using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedWoman : Player
{
    public override void Initialize()
    {
        pd.maxHp = 50;
        pd.curHp = pd.maxHp;
        pd.speed = 7f;
        pd.attack = 10f;
        pd.level = 1;
        pd.maxExperience = 1000;
        pd.curExperience = 0;
        pd.enemy = FindAnyObjectByType<Enemy>();
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
