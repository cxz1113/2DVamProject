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

    void OnButtonWeapon()
    {

    }
    public UICard SetWeapon()
    {
        this.weapon = weapons[Random.Range(0, weapons.Count)];
        spImage.sprite = weapon.weaponSprite;
        Name = weapon.name;
        return this;
    }
}
