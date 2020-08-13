using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private List<WaveScript> _waveScripts;
    private int startWave = 0;
    void Start()
    {
        var currentWave = _waveScripts[startWave];
        StartCoroutine(SpawnAllEnemiesOfTheWave(currentWave));
    }

    IEnumerator SpawnAllEnemiesOfTheWave(WaveScript waveScript)
    {
        for (int i = 0; i < waveScript.GetNumberOfEnemies(); i++)
        {
            Instantiate(
                waveScript.GetEnemyPrefab(),
                waveScript.GetWaypoints()[0].position,
                Quaternion.identity);
            yield return new WaitForSeconds(waveScript.GetTimeBetweenSpawns());
        }
    }

    void Update()
    {
        
    }
}
