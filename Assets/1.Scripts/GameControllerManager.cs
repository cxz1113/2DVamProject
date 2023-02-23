using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerManager : MonoBehaviour
{
    public static GameControllerManager instance;
    public Player player;

    void Awake() { instance = this; }   
}
