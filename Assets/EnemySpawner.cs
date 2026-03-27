using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 0.5f;
    void Start()
    {
        //spawnuj wroga co 3 sekundy, zaczynaj¹c od razu
        InvokeRepeating("Spawn", 0f, spawnInterval);
    }
    void Spawn()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}
