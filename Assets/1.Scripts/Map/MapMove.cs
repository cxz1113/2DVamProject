using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        /*if (!collision.CompareTag("Area"))
            return;
        Vector3 playerPos = GameMapManager.instance.player.transform.position;
        Vector3 mapPos = transform.position;
        float diffX = Mathf.Abs(playerPos.x - mapPos.x);
        float diffY = Mathf.Abs(playerPos.y - mapPos.y);

        Vector3 playerDir = GameMapManager.instance.player.inputVec;
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;

        if(collision.transform)
        {
            if (diffX > diffY)
            {
                transform.Translate(Vector3.right * dirX * 40);
            }
            else if (diffX < diffY)
            {
                transform.Translate(Vector3.up * dirY * 40);
            }
        }*/
    }
}
