using System.Collections;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField]
    private IntVariable _currentWave;
    [SerializeField]
    private float _timeBetweenWaves;
    [SerializeField]
    private int _waveCount;

    //TODO fix all this logic, this is only here to delivery something

    private void Awake()
    {
        StartCoroutine(SpawnWaves());
    }
    private IEnumerator SpawnWaves()
    {
        while (_currentWave.Value < _waveCount)
        {
            yield return new WaitForSeconds(_timeBetweenWaves);
            _currentWave.Value++;
        }
    }

}
