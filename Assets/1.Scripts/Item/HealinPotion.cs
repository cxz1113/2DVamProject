using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealinPotion : Item
{
    public override void Initialize()
    {
        id.hp = Player.Instance.pd.maxHp / 2;
        ItemType = ItemType.HealingPotion;
        id.obj = gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }
}
