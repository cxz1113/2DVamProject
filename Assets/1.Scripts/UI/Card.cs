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

    void Start()
    {
        btn.onClick.AddListener(OnButtonWeapon);
    }

    void Update()
    {
        weaponTxt.text = string.Format($"{Name}");
    }

    void OnButtonWeapon()
    {
        Player player = GameControllerManager.instance.player;
        int count = player.mWeapons.Count;
        if(player.weapons.Contains(weapon))
        {
            if(weapon.gameObject.name == "Shovel")
            {
                Shovel shovel = weapon.GetComponentInChildren<Shovel>();
                
                if(player.mWeapons.Contains(shovel.meleeWeapon))
                {
                    player.mWeapons.Add(Instantiate(shovel.meleeWeapon, player.meleeHands[0+count]));
                }
                else
                {
                    player.mWeapons.Add(Instantiate(shovel.meleeWeapon, player.meleeHands[0]));
                }
            }
        }
        Destroy(player.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject);
        player.pd.weapon = Instantiate(weapon, player.hand);
        player.weapons.Add(weapon);
        GameControllerManager.instance.uiCont.gameObject.SetActive(false);
        player.IsLevel = false;
    }
    public void WeaponSet(Weapon weapon)
    {
        this.weapon = weapon;
        Name = weapon.name;
        wpImage.sprite = weapon.seletSprite;
    }
}
