using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SelectControllerManager : MonoBehaviour
{
    public static SelectControllerManager instance;
    public List<SelectCard> cards = new List<SelectCard>();
    public Player[] players;
    //public Transform parent;

    void Awake() { instance = this; }

    void Start()
    {
        //btn.onClick.AddListener(card.PlayerSetting);
        //CardSetting();
        PlayerSetting();
        //PlayerCard();
    }

    public void PlayerCard()
    {
        for(int i = 0; i < 4; i++)
        {
            //Instantiate(players[i], parent);
        }
    }

    public void PlayerSetting()
    {
        int count = 0;
        while(count < 4)
        {
            Player playerData = players[count];
            playerData.Initialize();
            cards[count].GetComponent<SelectCard>().PlayerSet(playerData);
            count++;
        }
    }
}
