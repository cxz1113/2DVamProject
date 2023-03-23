using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yeongmi : Player
{
    public override void Initialize()
    {
        pd.maxHp = 35;
        pd.curHp = pd.maxHp;
        pd.speed = 7f;
        pd.level = 1;
        pd.maxExperience = ((pd.level * (pd.level + 1)) * 25) - 50;
        pd.curExperience = 0;
        IsAlive = true;
        IsHide = false;
    }

    void Start()
    {
        Initialize();
        pd.weapon = Instantiate(weapon, hand);
        pd.weapon.transform.localPosition = Vector2.zero;
        weapons.Add(weapon);
        direction = Direction.Stand;
        GetComponent<SpriteAnimation>().SetSprite(idleSp, 0.2f);
    }
}
