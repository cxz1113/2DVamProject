using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMoving : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        Vector3 playerPos = GameMapManager.instance.player.transform.position;
        Vector3 mapPos = transform.position;

        float disX = Mathf.Abs(playerPos.x - mapPos.x);
        float disY = Mathf.Abs(playerPos.y - mapPos.y);

        Vector3 playerDir = GameMapManager.instance.player.inputVec;

        if(disX > disY)
        {
            if(playerDir.x > 0)
            {
                transform.Translate(Vector3.right * 40);
            }
            else
            {
                transform.Translate(Vector3.left * 40);
            }
        }
        if(disX < disY)
        {
            if(playerDir.y > 0)
            {
                transform.Translate(Vector3.up * 40);
            }
            else
            {
                transform.Translate(Vector3.down * 40);
            }
        }
    }
}
