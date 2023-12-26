using UnityEngine;
using System.Collections.Generic;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab;
    public float initialSpawnRate = 2f;
    public List<GameObject> meteorList = new List<GameObject>();
    private float spawnRate;
    private float nextSpawnTime = 0f;
    private bool _pauseSpawn;
    private float _spawnRateMultiplier = 0.1f;

    public void PauseSpawn() { 
        _pauseSpawn = true;
    }

    public void IncreaseSpawnRate(float rate)
    {
        _spawnRateMultiplier = rate;
    }


    void Start()
    {
        spawnRate = initialSpawnRate;
    }

    void Update()
    {
        if (_pauseSpawn) { return; }
        
        if (Time.time >= nextSpawnTime)
        {
            SpawnMeteor();
            nextSpawnTime = Time.time + 1f / spawnRate;

            // Increase spawn rate over time
            spawnRate += Time.deltaTime * _spawnRateMultiplier; // Adjust the rate of increase as needed
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

        meteorList.Add(newMeteor);
        
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

    void SetSpeedMultiplier(float speedMultiplier) {
        Debug.Log("Setting multiplier");
        Meteor.speedMultiplier = speedMultiplier;
    }

}
