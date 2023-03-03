using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedWoman : Player
{
    public override void Initialize()
    {
        pd.maxHp = ((pd.level + (pd.level + 1)) * 25) - 25;
        pd.curHp = pd.maxHp;
        pd.speed = 7f;
        pd.attack = 10f;
        pd.level = 1;
        pd.maxExperience = ((pd.level * (pd.level + 1)) * 25) - 50;
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
