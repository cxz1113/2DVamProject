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
        if (player.weapons.Contains(weapon))
        {
            Shovel shovel = weapon.GetComponentInChildren<Shovel>();

            if (weapon.gameObject.name == "Shovel")
            {
                if (weapon.wd.level > player.meleeHands.Count)
                {
                    shovel.wd.attack += 5;
                    shovel.meleeWeapon.wd.attack += 20;
                }
                else
                {
                    foreach (var item in player.meleeHands)
                    {
                        item.gameObject.SetActive(false);
                    }
                        
                    int val = 360 / weapon.Level;
                    int tempVal = val;
                    for (int i = 0; i < weapon.wd.level; i++)
                    {
                        player.meleeHands[i].gameObject.SetActive(true);
                        player.meleeHands[i].rotation = Quaternion.Euler(new Vector3(0f, 0f, tempVal));
                        tempVal += val;
                        Debug.Log(tempVal);
                    }
                }
            }
            weapon.wd.level++;
            Debug.Log(weapon.wd.level);
        }
        Destroy(player.transform.GetChild(1).transform.GetChild(0).gameObject);
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
        //this.weapon.Initialize();
        Debug.Log(weapon.Level);
    }
}
