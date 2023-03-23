using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteAnimation>().SetSprite(sprites, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
