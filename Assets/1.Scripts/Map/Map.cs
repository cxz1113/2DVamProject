using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Map : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (transform.CompareTag("Area"))
            return;
        else if (collision.CompareTag("Enemy"))
            return;
        else if (collision.CompareTag("Bullet"))
            return;
        else if (collision.CompareTag("player"))
            return;
        Vector3 playerPos = GameControllerManager.instance.player.transform.position;
        Vector3 mapPos = transform.position;

        float distanceX = Mathf.Abs(playerPos.x - mapPos.x);
        float distanceY = Mathf.Abs(playerPos.y - mapPos.y);

        playerPos.x = Input.GetAxisRaw("Horizontal");
        playerPos.y = Input.GetAxisRaw("Vertical");

        
            if (Mathf.Abs(distanceX - distanceY) <= 0.1f)
            {
                if (playerPos.x > 0)
                {
                    transform.Translate(Vector3.right * 40);
                }
                else
                {
                    transform.Translate(Vector3.left * 40);
                }
                if (playerPos.y > 0)
                {
                    transform.Translate(Vector3.up * 40);
                }
                else
                {
                    transform.Translate(Vector3.down * 40);
                }
            }
            else if (distanceX > distanceY)
            {
                if (playerPos.x > 0)
                {
                    transform.Translate(Vector3.right * 40);
                }
                else
                {
                    transform.Translate(Vector3.left * 40);
                }
            }
            else if (distanceX < distanceY)
            {
                if (playerPos.y > 0)
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
