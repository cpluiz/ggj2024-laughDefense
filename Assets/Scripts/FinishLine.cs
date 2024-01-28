using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField]
    private IntVariable _serotonineCount;
    [SerializeField]
    private IntVariable _dopamineCount;
    [SerializeField]
    private IntVariable _anxietyCount;
    [SerializeField]
    private IntVariable _depressionCount;

    private void OnTriggerEnter(Collider other)
    {
        //TODO Implement all the logic
        Destroy(other.gameObject);
    }
}
