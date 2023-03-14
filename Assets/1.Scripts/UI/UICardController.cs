using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UICardController : MonoBehaviour
{    
    public List<UICard> uiCards = new List<UICard>();
    public List<GameObject> objects = new List<GameObject>();
    public UICard uiCard;
    // Start is called before the first frame update
    void Start()
    {
        //ItemCard();
    }

    void ItemCard()
    {
        /*GameObject obj = null;
        for(int i = 0; i < uiCards.Count; i++)
        {
            for(int j = 0; j < objects.Count; j++)
            {
                if (uiCards[i] == uiCard.objects[j])
                    return;
                else
                {
                    int rand = Random.Range(0, 101);
                    if (rand > 25)
                    {
                        obj = objects[Random.Range(0, 2)];
                        uiCard.spImage.sprite = obj.GetComponent<SpriteRenderer>().sprite;
                        uiCard.uiText.text = string.Format($"{obj.gameObject.name}");
                    }
                    else if (rand <= 25)
                    {
                        obj = objects[Random.Range(3, objects.Count)];
                        uiCard.spImage.sprite = obj.GetComponent<Weapon>().weaponSprite;
                        uiCard.uiText.text = string.Format($"{obj.gameObject.name}");
                    }
                }
            }
        }*/
    }
}
