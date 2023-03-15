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
    public List<Weapon> randWeapons;
    public Queue<Weapon> cards = new Queue<Weapon>();
    Weapon weapon;


    public string Name { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(OnButtonWeapon);
    }

    void Update()
    {
        uiText.text = string.Format($"{Name}");
    }

    internal void SetWeapon(object v)
    {
        throw new System.NotImplementedException();
    }

    void OnButtonWeapon()
    {
        Player player = GameControllerManager.instance.player;
        Destroy(player.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject);
        player.pd.weapon = Instantiate(weapon, player.hand);
        player.weapon = weapon;
        player.weapons.Add(weapon);
        GameControllerManager.instance.uiCont.gameObject.SetActive(false);
    }

    public UICard SetWeapons()
    {
        List<Weapon> weapon = new List<Weapon>();
        int count = 0;
        while(count < 2)
        {
            Weapon wp = weapons[Random.Range(0, weapons.Count)];

            if (!weapon.Contains(wp))
            {
                weapon.Add(wp);
                
                spImage.sprite = wp.GetComponent<SpriteRenderer>().sprite;
                count++;
            }
        }
        return this;
    }
    public UICard SetWeapon()
    {
        Weapon randWeapon = weapons[Random.Range(0, weapons.Count)];
        int count = 0;
        while(count < 2)
        {
            if (randWeapon != this.weapon)
            {
                this.weapon = randWeapon;
                spImage.sprite = weapon.GetComponent<SpriteRenderer>().sprite;
                Name = weapon.name;
                count++;
            }
        }
        return this;
    }
}

