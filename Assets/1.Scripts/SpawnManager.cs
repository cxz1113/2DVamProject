using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Enemy[] prefabs;
    [SerializeField] private Transform[] trans;
    [SerializeField] private Transform parent;

    float spawnDelay = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spawnDelay += Time.deltaTime;
        if(spawnDelay > 1f)
        {
            spawnDelay = 0;
            Phase4(prefabs, trans);
        }

        /*spawnDelay += Time.deltaTime;
        if(spawnDelay > 1.5f)
        {
            spawnDelay = 0;
            if (GameControllerManager.instance.player.pd.level <= 3)
            {
                Phase1(prefabs, trans, 0);
            }
            else if(GameControllerManager.instance.player.pd.level > 3 && GameControllerManager.instance.player.pd.level <= 5)
            {
                Phase2(prefabs, trans);
            }
            else if(GameControllerManager.instance.player.pd.level > 5  && GameControllerManager.instance.player.pd.level <= 8)
            {
                Phase3(prefabs, trans);
            }
            else if (GameControllerManager.instance.player.pd.level > 8 && GameControllerManager.instance.player.pd.level <= 10)
            {
                Phase4(prefabs, trans);
            }
        }*/
    }


    public void Phase1(Enemy[] enemies, Transform[] trans, int index)
    {
        int rand = Random.Range(0, prefabs.Length);
        int transRand = Random.Range(0, trans.Length);
        Enemy enemy = Instantiate(enemies[index], trans[transRand]);
        enemy.Initialize();
        enemy.transform.SetParent(parent);
    }
    public void Phase2(Enemy[] enemies, Transform[] trans)
    {
        int rand = Random.Range(0, 2);
        int transRand = Random.Range(0, trans.Length);
        Enemy enemy = Instantiate(enemies[rand], trans[transRand]);
        enemy.Initialize();
        enemy.transform.SetParent(parent);
    }
    public void Phase3(Enemy[] enemies, Transform[] trans)
    {
        int rand = Random.Range(0, 3);
        int transRand = Random.Range(0, trans.Length);
        Enemy enemy = Instantiate(enemies[rand], trans[transRand]);
        enemy.Initialize();
        enemy.transform.SetParent(parent);
    }

    public void Phase4(Enemy[] enemies, Transform[] trans)
    {
        int rand = Random.Range(0, prefabs.Length);
        int transRand = Random.Range(0, trans.Length);
        Enemy enemy = Instantiate(enemies[rand], trans[transRand]);
        enemy.Initialize();
        enemy.transform.SetParent(parent);
    }


    public void Spawn()
    {
        InvokeRepeating("EnemyPawn", 2f, 3f);
    }    
}
