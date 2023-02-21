using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMapManager : MonoBehaviour
{
    public static GameMapManager instance;
    public Player player;

    void Awake() { instance = this; }   
}
