using UnityEngine;
[CreateAssetMenu(fileName = "EnemyWaveContent", menuName = "Enemy/EnemyWave")]
public class EnemyWave : ScriptableObject
{
    [SerializeField]
    public EnemyWaveContent[] waveContent;
}
[System.Serializable]
public class EnemyWaveContent
{
    public EnemyDescriptor enemyDescriptor;
    public int troopsInThisWave;
    public float intervalBetweenSpawn;
}