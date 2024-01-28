using System.Collections;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] private NeurotransmiterDescriptor m_descriptor;
    [SerializeField] private Transform[] m_Target;
    [SerializeField] private GameObject m_SpawnPoint;

    private TowerDescriptor _towerDescriptor;
    private Coroutine _spawnCoroutine;

    private void Awake()
    {
        FinishLine[] exits = GameObject.FindObjectsByType<FinishLine>(FindObjectsSortMode.None);
        m_Target = new Transform[exits.Length];
        for(int i = 0; i < exits.Length; i++)
        {
            m_Target[i] = exits[i].transform;
        }
    }

    public void SetTowerDescriptor(TowerDescriptor towerDescriptor)
    {
        _towerDescriptor = towerDescriptor;
    }

    public void StartSpawning()
    {
        if(_spawnCoroutine == null)
        {
            _spawnCoroutine = StartCoroutine(CO_SpawnTroops());
        }
    }

    public void StopSpawning()
    {
        if(_spawnCoroutine != null)
        {
            StopCoroutine(_spawnCoroutine);
            _spawnCoroutine = null;
        }
    }

    private void OnDestroy()
    {
        StopSpawning();
    }

    //TODO track interavall between spawns to show a floating loading bar above the tower
    private IEnumerator CO_SpawnTroops()
    {
        float nextSpawnTime = Time.time + _towerDescriptor.SpawnInterval;
        Neurotransmiter neurotransmiter;
        while(true)
        {
            if(Time.time >= nextSpawnTime)
            {
                neurotransmiter = Instantiate<Neurotransmiter>(m_descriptor.prefab, m_SpawnPoint.transform.position, m_SpawnPoint.transform.rotation);
                neurotransmiter.SetNeurotransmiterValues(m_descriptor, m_Target[Random.Range(0, m_Target.Length)]);
                nextSpawnTime = Time.time + _towerDescriptor.SpawnInterval;
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
