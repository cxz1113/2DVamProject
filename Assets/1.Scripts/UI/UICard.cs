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
    public List<Weapon> weapons = new List<Weapon>();
    public List<Item> items = new List<Item>();

    public List<GameObject> objects = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(OnButtonSelect);
        //Spawn();
        GameObjectSpawn();
    }

    void OnButtonSelect()
    {

    }

    void GameObjectSpawn()
    {
        int rand = Random.Range(0, 100);
        if (rand > 25)
        {            
            GameObject obj = Instantiate(objects[Random.Range(0, 2)], transform);
            spImage.sprite = obj.GetComponent<SpriteRenderer>().sprite;
        }
        else if (rand <= 25)
        {
            Weapon weapon = Instantiate(weapons[Random.Range(0, weapons.Count)], transform);
            spImage.sprite = weapon.GetComponent<SpriteRenderer>().sprite;
        }
    }
    void Spawn()
    {
        int rand = Random.Range(0, 100);
        if(rand > 25)
        {
            Item item = Instantiate(items[Random.Range(0, items.Count)], transform);
            spImage.sprite = item.GetComponent<SpriteRenderer>().sprite;
            Text(item);
        }
        else if(rand <= 25)
        {
            Weapon weapon = Instantiate(weapons[Random.Range(0, weapons.Count)], transform);
            spImage.sprite = weapon.GetComponent<SpriteRenderer>().sprite;
        }
    }

    void Text(Item item)
    {
        switch(item.gameObject.name)
        {
            case "PowerUp":
                uiText.text = string.Format("{Power Up!! + 2}",item);
                break;
            case "SpeedUp":
                uiText.text = string.Format("{Speed Up!! + 2}");
                break;
        }
    }
}
