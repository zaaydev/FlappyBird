using UnityEngine;

public class SpawnPipesScript : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    private float spawnTimer = 0;
    private bool canSpawn = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (!canSpawn) return;

        if (spawnTimer > 2) {
            SpawnPipe();
            spawnTimer = 0;
        } else {
            spawnTimer += Time.deltaTime;
        }
    }

    void SpawnPipe() {
        float randomYPosition = Random.Range(-10f, 10f);
        Instantiate(obstaclePrefab, new Vector3(transform.position.x, randomYPosition, transform.position.z), transform.rotation);

    }

    public void StopSpawning() {
        canSpawn = false;
    }
}
