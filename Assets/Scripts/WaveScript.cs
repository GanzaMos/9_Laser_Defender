using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config", fileName = "Wave")]
public class WaveScript : ScriptableObject
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.3f;
    [SerializeField] float randomSpawnTimeFactor = 0.2f;
    [SerializeField] int numberOfEnemies = 2;
    [SerializeField] float enemiesSpeed = 2f;

    public GameObject GetEnemyPrefab() { return enemyPrefab; }
    public float GetTimeBetweenSpawns() { return timeBetweenSpawns; }
    public float GetRandomSpawnTimeFactor() { return randomSpawnTimeFactor; }
    public float GetEnemiesSpeed() { return enemiesSpeed; }
    public int GetNumberOfEnemies() { return numberOfEnemies; }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in pathPrefab.transform)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }
    
}
