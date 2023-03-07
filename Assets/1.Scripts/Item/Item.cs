using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public struct ItemData
{
    public float score;
    public float hp;
    public GameObject obj;
}

public enum ItemType
{
    None,
    Ex0,
    Ex1,
    Ex2,
    HealingPotion,
    Shadow
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
        switch(ItemType)
        {
            case ItemType.Ex0:
                GameControllerManager.instance.player.CurExperience += id.score;
                break;
            case ItemType.Ex1:
                GameControllerManager.instance.player.CurExperience += id.score;
                break;
            case ItemType.Ex2:
                GameControllerManager.instance.player.CurExperience += id.score;
                break;
            case ItemType.HealingPotion:
                if (GameControllerManager.instance.player.HP >= GameControllerManager.instance.player.pd.maxHp)
                    return;
                GameControllerManager.instance.player.HP += id.hp;
                break;
            case ItemType.Shadow:
                StartCoroutine(Hide(4));
                
                //Invoke("fHide", 4f);
                Debug.Log(GameControllerManager.instance.player.IsHide);
                break;
        }        
    }

    IEnumerator Hide(int time)
    {
        int count = time;
        while(true)
        {
            GameControllerManager.instance.player.IsHide = true;
            GameControllerManager.instance.player.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            yield return new WaitForSeconds(1f);
            count--;
            if(count <= 0)
            {
                GameControllerManager.instance.player.IsHide = false;
                GameControllerManager.instance.player.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
                break;
            }
        }
            
    }
    void fHide()
    {
        GameControllerManager.instance.player.IsHide = true;
        GameControllerManager.instance.player.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);        
    }
}