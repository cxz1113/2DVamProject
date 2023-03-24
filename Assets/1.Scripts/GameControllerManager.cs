using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameControllerManager : MonoBehaviour
{
    public static GameControllerManager instance;
    public Player player;
    public UIManager uiCont;
    public Enemy[] enemys;
    public Transform playerStart;

    void Awake() 
    { 
        instance = this;

        //Player player = Instantiate(Player.Instance);
        GameObject obj = Instantiate(Player.Instance.gameObject);
        if (player == null)
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }   
}
