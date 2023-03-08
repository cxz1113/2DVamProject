using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameControllerManager : MonoBehaviour
{
    public static GameControllerManager instance;
    public Player player;
    public UIManager uiCont;
    void Awake() { instance = this; }   
}
