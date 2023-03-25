using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public struct ItemData
{
    public float score;
    public float hp;
    public float attack;
    public float speed;
    public GameObject obj;
}

public enum ItemType
{
    None,
    Ex0,
    Ex1,
    Ex2,
    HealingPotion,
    Shadow,
    Attack,
    Speed
}
public abstract class Item : MonoBehaviour
{
    public ItemData id = new ItemData();
    public ItemType ItemType;

    public abstract void Initialize();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Area"))
            return;
        else if(collision.CompareTag("player"))
        {
            ItemSelect();
            Destroy(gameObject);
        }
    }

    public void ItemSelect()
    {
        Player player = Player.Instance;
        switch(ItemType)
        {
            case ItemType.Ex0:
                player.CurExperience += id.score;
                break;
            case ItemType.Ex1:
                player.CurExperience += id.score;
                break;
            case ItemType.Ex2:
                player.CurExperience += id.score;
                break;
            case ItemType.HealingPotion:
                if (player.HP >= player.pd.maxHp)
                    return;
                player.HP += id.hp;
                break;
            case ItemType.Shadow:
                player.StartCoroutine("Hide");
                break;
        }        
    }
}
