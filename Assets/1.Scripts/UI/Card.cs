using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{
    [SerializeField] private Image wpImage;
    [SerializeField] private TMP_Text weaponTxt;
    [SerializeField] private Button btn;

    public string Name { get; set; }
    Weapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        WeaponSet(GameControllerManager.instance.uiCont.Card());
    }

    // Update is called once per frame
    void Update()
    {
        weaponTxt.text = string.Format($"{Name}");
    }

    void WeaponSet(Weapon card)
    {
        weapon = card;
        wpImage.sprite = weapon.GetComponent<SpriteRenderer>().sprite;
        Name = weapon.name;
    }
}
