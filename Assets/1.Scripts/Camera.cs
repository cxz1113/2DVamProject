using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Player player = GameControllerManager.instance.player;
        Vector3 dir = player.transform.position - transform.position;
        Vector3 move = new Vector3(dir.x * Time.deltaTime * 10f, dir.y * Time.deltaTime * 10f, 0f);
        transform.Translate(move);
    }
}
