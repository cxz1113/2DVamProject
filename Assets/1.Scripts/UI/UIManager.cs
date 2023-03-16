using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    public List<Image> image;
    public List<Weapon> weapons = new List<Weapon>();
    // Start is called before the first frame update
    void Start()
    {
        Card();
    }

    public void Card()
    {
        List<Weapon> weapon = new List<Weapon>();
        int count = 0;
        while(count < 3)
        {
            Weapon wp = weapons[Random.Range(0, weapons.Count)];
            if (!weapon.Contains(wp))
            {
                weapon.Add(wp);
                image[count].GetComponent<Card>().WeaponSet(wp);
                count++;
            }
        }
    }
}
