using UnityEngine;
[CreateAssetMenu(fileName = "TowerDescriptor", menuName = "Descriptors/TowerDescriptor")]
public class TowerDescriptor : ScriptableObject
{
    public Sprite Photo;
    public int Cost;
    public float SpawnInterval;
    public NeurotransmiterDescriptor Neurotransmiter;
    public TowerSpawner prefab;
}