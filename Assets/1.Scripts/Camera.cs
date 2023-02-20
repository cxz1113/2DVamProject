using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = player.transform.position - transform.position;
        Vector3 move = new Vector3(dir.x * Time.deltaTime * 5f, dir.y * Time.deltaTime * 5f, 0f);
        transform.Translate(move);
    }
}
