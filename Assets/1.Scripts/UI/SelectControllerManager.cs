using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectControllerManager : MonoBehaviour
{
    public static SelectControllerManager instance;
    public List<SelectCard> cards = new List<SelectCard>();
    public Player[] players;
    public Transform parent;


    void Awake() { instance = this; }

    void Start()
    {
        //CardSetting();
        PlayerSetting();
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
