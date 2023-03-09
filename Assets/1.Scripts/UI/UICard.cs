using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UICard : MonoBehaviour
{
    [SerializeField] private Button btn;
    [SerializeField] private Image spImage;
    [SerializeField] private TMP_Text uiText;
    public List<Item> items = new List<Item>();
    public List<Weapon> weapons = new List<Weapon>();
    public List<UICard> objects = new List<UICard>();

    // Start is called before the first frame update
    void Start()
    {
        GameObjectSpawn();
    }


    void GameObjectSpawn()
    {
        int rand = Random.Range(0, 100);
        GameObject obj = null;

        if (rand > 25)
        {
            obj = GameControllerManager.instance.uiCardCont.objects[Random.Range(0, 2)];
            spImage.sprite = obj.GetComponent<SpriteRenderer>().sprite;
            uiText.text = string.Format($"{obj.gameObject.name} + 2Up!!");
        }
        else if (rand <= 25)
        {
            obj = GameControllerManager.instance.uiCardCont.objects[Random.Range(3, GameControllerManager.instance.uiCardCont.objects.Count)];
            spImage.sprite = obj.GetComponent<SpriteRenderer>().sprite;
            uiText.text = string.Format($"{obj.gameObject.name}");
        }
    }

    void Spawn()
    {
        int rand = Random.Range(0, 100);
        if (rand > 25)
        {
            UICard uiCard = objects[Random.Range(0, 2)];
            spImage.sprite = uiCard.GetComponent<SpriteRenderer>().sprite;
            uiText.text = string.Format($"{uiCard.gameObject.name} + 2Up!!");
        }
        else if (rand <= 25)
        {
            UICard uiCard = objects[Random.Range(0, objects.Count)];
            spImage.sprite = uiCard.GetComponent<SpriteRenderer>().sprite;
            uiText.text = string.Format($"{uiCard.gameObject.name}");
        }
    }
}
