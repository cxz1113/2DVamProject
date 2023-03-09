using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UICardController : MonoBehaviour
{
    public List<Image> myCards = new List<Image>();
    public List<GameObject> objects = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        Card();
    }

    void Card()
    {
        for(int i = 0; i < myCards.Count; i++)
        {
            for(int j = 0; j < objects.Count; j++)
            {
                if (myCards[i].gameObject == objects[j].gameObject)
                    return;
            }
        }
    }
}
