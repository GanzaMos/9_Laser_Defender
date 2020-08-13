using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private List<WaveScript> _waveScripts;
    private int startWave = 0;
    void Start()
    {
        StartCoroutine(SpawnAllWaves());
    }

    IEnumerator SpawnAllWaves()
    {
        for (int currentWave = startWave; currentWave < _waveScripts.Count; currentWave++)
        {
            yield return StartCoroutine(SpawnAllEnemiesOfTheWave(_waveScripts[currentWave]));
        }
    }

    IEnumerator SpawnAllEnemiesOfTheWave(WaveScript waveScript)
    {
        for (int i = 0; i < waveScript.GetNumberOfEnemies(); i++)
        {
            var enemy = Instantiate(
                waveScript.GetEnemyPrefab(),
                waveScript.GetWaypoints()[0].position,
                Quaternion.identity);
            enemy.GetComponent<EnemyMovement>().SetWaveConfig(waveScript);
            yield return new WaitForSeconds(waveScript.GetTimeBetweenSpawns());
        }
    }

    void Update()
    {
        
    }
}
