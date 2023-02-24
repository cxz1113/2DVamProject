using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Enemy[] prefabs;
    [SerializeField] private Transform[] trans;
    [SerializeField] private Transform parent;
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnemyPawn()
    {
        int rand = Random.Range(0, prefabs.Length);
        int transRand = Random.Range(0, trans.Length);
        Enemy enemy = Instantiate(prefabs[rand],trans[transRand]);
        enemy.Initialize();
        enemy.transform.SetParent(parent);
    }

    public void Spawn()
    {
        InvokeRepeating("EnemyPawn", 2f, 3f);
    }

    
}
