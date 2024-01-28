using Cinemachine;
using UnityEngine;
[CreateAssetMenu(fileName = "EnemyDescriptor", menuName = "Descriptors/EnemyDescriptor")]
public class EnemyDescriptor : BrainComponentDescriptor
{
    public Enemy prefab;
    [TagField, SerializeField] public string[] AbsorbsFrom;
}
