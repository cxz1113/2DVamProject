using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIUndead : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites;
    float delayTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteAnimation>().SetSprite(sprites, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        delayTime += Time.deltaTime;
        if(delayTime > 10.5)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            transform.Translate(Vector3.left * Time.deltaTime * 4.5f);
            if(delayTime > 17)
            {
                Destroy(gameObject);
            }
        }
    }
}
