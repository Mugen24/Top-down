using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab;
    public float initialSpawnRate = 2f;
    public GameObject MeteorList;
    private float spawnRate;
    private float nextSpawnTime = 0f;

    void Start()
    {
        spawnRate = initialSpawnRate;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnMeteor();
            nextSpawnTime = Time.time + 1f / spawnRate;

            // Increase spawn rate over time
            spawnRate += Time.deltaTime * 0.1f; // Adjust the rate of increase as needed
        }
    }

    void SpawnMeteor()
    {
        Vector2 spawnPosition = GetRandomSpawnPosition();
        GameObject newMeteor = Instantiate(meteorPrefab, spawnPosition, Quaternion.identity);

        // Randomize meteor color
        SpriteRenderer sr = newMeteor.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            Color[] colors = { Color.white, Color.blue, Color.red };
            sr.color = colors[Random.Range(0, colors.Length)];
        }
    }

    Vector2 GetRandomSpawnPosition()
    {
        float x, y;

        // Randomly choose an edge to spawn from (top, bottom, left, right)
        switch (Random.Range(0, 4))
        {
            case 0: // Top
                x = Random.Range(0, Screen.width);
                y = Screen.height;
                break;
            case 1: // Bottom
                x = Random.Range(0, Screen.width);
                y = 0;
                break;
            case 2: // Left
                x = 0;
                y = Random.Range(0, Screen.height);
                break;
            default: // Right
                x = Screen.width;
                y = Random.Range(0, Screen.height);
                break;
        }

        // Convert screen position to world position
        return Camera.main.ScreenToWorldPoint(new Vector3(x, y, 0));
    }
}
