using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] private UICard[] uiCards;
    public UICard uiCard;
    // Start is called before the first frame update
    void Start()
    {
        CardSpawn();
    }


    void CardSpawn()
    {
        for(int i = 0; i < 2; i++)
        {
            uiCards[i].SetWeapon();
        }
    }
}
