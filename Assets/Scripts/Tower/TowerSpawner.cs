using System.Collections;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] private NeurotransmiterDescriptor m_descriptor;
    [SerializeField] private Transform[] m_Target;
    [SerializeField] private GameObject m_SpawnPoint;
    [SerializeField] private float _spawnIntervall;

    private Coroutine _spawnCoroutine;

    private void Awake()
    {
        _spawnCoroutine = StartCoroutine(CO_SpawnTroops());
    }

    private void OnDestroy()
    {
        StopCoroutine(_spawnCoroutine);
        _spawnCoroutine = null;
    }

    //TODO track interavall between spawns to show a floating loading bar above the tower
    private IEnumerator CO_SpawnTroops()
    {
        float nextSpawnTime = Time.time + _spawnIntervall;
        Neurotransmiter neurotransmiter;
        while(true)
        {
            if(Time.time >= nextSpawnTime)
            {
                neurotransmiter = Instantiate<Neurotransmiter>(m_descriptor.prefab, m_SpawnPoint.transform.position, m_SpawnPoint.transform.rotation);
                neurotransmiter.SetNeurotransmiterValues(m_descriptor, m_Target[Random.Range(0, m_Target.Length)]);
                nextSpawnTime = Time.time + _spawnIntervall;
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
