using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    public List<Weapon> weapons = new List<Weapon>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Weapon Card()
    {
        List<Weapon> weapon = new List<Weapon>();
        int count = 0;
        while(count < 3)
        {
            Weapon wp = weapons[Random.Range(0, weapons.Count)];
            if (weapon.Contains(wp))
                return wp;
            else
            {
                weapon.Add(wp);
                count++;
            }
        }
        return weapon[Random.Range(0, weapon.Count)];
    }
}
