using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMan : Player
{
    public override void Initialize()
    {
        pd.maxHp = 50;
        pd.curHp = pd.maxHp;
        pd.speed = 4.5f;
        pd.attack = 5;
        pd.level = 1;
        pd.maxExperience = ((pd.level * (pd.level + 1)) * 25) - 50;
        pd.curExperience = 0;
        pd.enemy = FindAnyObjectByType<Enemy>();
        IsAlive = true;
    }

    void Start()
    {
        Initialize();
        direction = Direction.Stand;
        GetComponent<SpriteAnimation>().SetSprite(idleSp, 0.2f);
    }
}
