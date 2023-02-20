using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimation : MonoBehaviour
{
    private List<Sprite> sprites = new List<Sprite>();
    private SpriteRenderer sr;

    private float spriteDelayTime;
    private float delayTime = 0;
    int spriteIndex = 0;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Sprite List로 사용하여 Sprite사용
    void Update()
    {
        if (sprites.Count == 0)
            return;

        delayTime += Time.deltaTime;
        if (delayTime > spriteDelayTime)
        {
            delayTime = 0;
            sr.sprite = sprites[spriteIndex];
            spriteIndex++;
            if (spriteIndex > sprites.Count - 1)
            {
                spriteIndex = 0;
            }
        }
    }

    public void SetSprite(List<Sprite> sprite, float delay)
    {
        sprites = sprite;
        spriteDelayTime = delay;
        spriteIndex = 0;
    }
}
