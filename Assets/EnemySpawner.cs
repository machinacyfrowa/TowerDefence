using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 0.5f;
    public List<GameObject> enemyList = new List<GameObject>();
    void Start()
    {
        //spawnuj wroga co 3 sekundy, zaczynaj¹c od razu
        InvokeRepeating("Spawn", 0f, spawnInterval);
    }
    void Spawn()
    {
        if(enemyList.Count > 0)
        {   //jeœli lista wrogów nie jest pusta,
            //to zespawnuj pierwszego wroga z listy i usuñ go z listy
            Instantiate(enemyList[0], transform.position, Quaternion.identity);
            enemyList.RemoveAt(0);
        }
        
    }
}
