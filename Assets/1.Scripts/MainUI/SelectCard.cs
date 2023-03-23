using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SelectCard : MonoBehaviour
{
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

    void Start()
    {
        btn.onClick.AddListener(OnButtonStart);
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
        SceneManager.LoadScene(2);
        DontDestroyOnLoad(player);
        Instantiate(player, GameControllerManager.instance.playerStart);
    }

    public void PlayerSet(Player player)
    {
        this.player = player;
        Name = player.gameObject.name;
        image.sprite = player.GetComponent<SpriteRenderer>().sprite;
        HP = player.HP;
        Speed = player.pd.speed;
        WeaponName = player.weapon.name;
    }
}
