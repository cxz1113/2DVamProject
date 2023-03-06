using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
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

    void Init()
    {
        delayTime = 0f;
        sprites.Clear();
        spriteIndex = 0;
    }
    public void SetSprite(List<Sprite> argSprites, float delay)
    {
        Init();
        sprites = argSprites.ToList();
        spriteDelayTime = delay;
    }

    public void SetSprite(Sprite sprite, List<Sprite> argSprites, float delay)
    {
        Init();
        sr.sprite = sprite;
        StartCoroutine(ReturnSprite(argSprites, delay));
    }

    public void SetSprite(Sprite sprite, float delay, float disableTime)
    {
        Init();
        sr.sprite = sprite;
        StartCoroutine(DiesableSprite(disableTime));
    }

    IEnumerator DiesableSprite(float time)
    {
        yield return new WaitForSeconds(time);
        sr.sprite = null;
    }

    IEnumerator ReturnSprite(List<Sprite> argSprites, float delay)
    {
        yield return new WaitForSeconds(0.01f);
        SetSprite(argSprites, delay);
    }
}
