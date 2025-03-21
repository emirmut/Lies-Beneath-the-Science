using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnFrequency;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private PlayerController playerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        StartCoroutine(SpawnEnemies(spawnFrequency));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnEnemies(float spawnFrequency) {
        while (playerController.lives > 0) {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnFrequency);
        }
        yield return null;
    }
}
