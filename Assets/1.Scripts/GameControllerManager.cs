using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameControllerManager : MonoBehaviour
{
    public static GameControllerManager instance;
    public Player player;
    public UIManager uiCont;
    public Transform weaponTrans;
    public Image exImage;
    public TMP_Text levelTxt;

    void Awake() 
    {
        Player player = Instantiate(Player.Instance);
        this.player = player;
        this.player.exImage = exImage;
        this.player.levelTxt = levelTxt;
        this.player.parent = weaponTrans;
        
        //Destroy(Player.Instance.transform.gameObject);
        if (player == null)
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }   
}
