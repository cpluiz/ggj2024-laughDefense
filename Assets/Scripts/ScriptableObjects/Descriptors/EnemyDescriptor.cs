using Cinemachine;
using UnityEngine;
[CreateAssetMenu(fileName = "EnemyDescriptor", menuName = "Enemy/EnemyDescriptor")]
public class EnemyDescriptor : ScriptableObject
{
    public Enemy prefab;
    public Sprite Photo;
    public float WalkingSpeed;
    public float Life;
    public float Dammage;
    [TagField] public string Tag;
    [TagField, SerializeField] public string[] StrongAgainst;
    [TagField, SerializeField] public string[] AbsorbsFrom;
}
