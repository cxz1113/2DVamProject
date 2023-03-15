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
        //CardSpawn();
        Spawn();
    }

    void CardSpawn()
    {
        
    }

    void Spawn()
    {
        foreach(var item in uiCards)
        {
            item.SetWeapons();
        }
    }
}
