using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    void Start()
    {
        //spawnuj wroga co 3 sekundy, zaczynaj¹c od razu
        InvokeRepeating("Spawn", 0f, 0.5f);
    }
    void Spawn()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}
