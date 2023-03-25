using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class SelectCard : MonoBehaviour
{
    public static SelectCard Instance;

    [SerializeField] private Button btn;
    [SerializeField] private TMP_Text nameTxt;
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text hpTxt;
    [SerializeField] private TMP_Text speedTxt;
    [SerializeField] private TMP_Text weaponTxt;
    Player player;
    public string Name { get; set; }
    public float HP { get; set; }
    public float Speed { get; set; }
    public string WeaponName { get; set; }

    void Awake() { Instance = this; }

    void Start()
    {
        btn.onClick.AddListener(OnButtonStart);
        //PlayerSetting();
    }

    void Update()
    {
        nameTxt.text = string.Format($"{Name}");
        hpTxt.text = string.Format($"{HP}");
        speedTxt.text = string.Format($"{Speed}");
        weaponTxt.text = string.Format($"{WeaponName}");
    }

    void OnButtonStart()
    {
        DontDestroyOnLoad(player);
        SceneManager.LoadScene(2);
    }

    public void PlayerSetting()
    {
        player.Initialize();
        Name = player.gameObject.name;
        image.sprite = player.GetComponent<SpriteRenderer>().sprite;
        HP = player.HP;
        Speed = player.pd.speed;
        WeaponName = player.weapon.name;
    }

    public Player PlayerSet(Player player)
    {
        this.player = player;
        Name = player.gameObject.name;
        image.sprite = player.GetComponent<SpriteRenderer>().sprite;
        HP = player.HP;
        Speed = player.pd.speed;
        WeaponName = player.weapon.name;

        return this.player;
    }
}
