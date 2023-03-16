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
        btn.onClick.AddListener(OnButtonWeapon);
    }

    // Update is called once per frame
    void Update()
    {
        weaponTxt.text = string.Format($"{Name}");
    }

    void OnButtonWeapon()
    {
        Player player = GameControllerManager.instance.player;
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
        wpImage.sprite = weapon.GetComponent<SpriteRenderer>().sprite;
    }
}
