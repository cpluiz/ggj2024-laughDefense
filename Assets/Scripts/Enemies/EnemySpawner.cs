using System.Collections;
using UnityAtoms;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private EnemyWave[] waves;
    [SerializeField]
    private Transform[] targetPoint;

    private Coroutine _spawningWaveCoroutine;

    public void SetWave(int waveNumber)
    {
        if(waveNumber <= waves.Length)
        {
            _spawningWaveCoroutine = StartCoroutine(StartWaveSpawn(waveNumber - 1));
        }
    }

    private void OnDestroy()
    {
        if(_spawningWaveCoroutine != null )
        {
            StopCoroutine(_spawningWaveCoroutine);
        }
    }
    private IEnumerator StartWaveSpawn(int waveIndex)
    {
        EnemyWave currentWave = waves[waveIndex];
        foreach(EnemyWaveContent waveContent in currentWave.waveContent)
        {
            for(int i = 0; i<= waveContent.troopsInThisWave; i++)
            {
                Enemy newEnemy = Instantiate<Enemy>(waveContent.enemyDescriptor.prefab, transform.position, transform.rotation);
                int randomSpawn = Random.Range(0, targetPoint.Length);
                Debug.Log($"Spawning random with index {randomSpawn}: {targetPoint[randomSpawn].name}", gameObject);
                newEnemy.SetEnemyValues(waveContent.enemyDescriptor, targetPoint[randomSpawn]);
                yield return new WaitForSeconds(waveContent.intervalBetweenSpawn);
            }
        }
    }
}
