using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICard : MonoBehaviour
{
    [SerializeField] private Button btn;
    public List<Weapon> weapons = new List<Weapon>();
    public List<Item> items = new List<Item>();
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(OnButtonSelect);
    }

    void OnButtonSelect()
    {

    }

    void Spawn()
    {
        int rand = Random.Range(0, 100);
        if(rand > 25)
        {
            Instantiate(items[Random.Range(0, items.Count)], transform);
        }
        else if(rand <= 25)
        {
        }
    }
}
