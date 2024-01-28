using Cinemachine;
using UnityEngine;

public class BrainComponentDescriptor : ScriptableObject
{
    public float WalkingSpeed;
    public float Life;
    public float Dammage;
    [TagField] public string Tag;
    [TagField, SerializeField] public string[] StrongAgainst;
}