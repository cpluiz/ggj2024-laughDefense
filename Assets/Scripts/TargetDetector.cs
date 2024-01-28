using UnityEngine;
using Cinemachine;
using System.Collections.Generic;
using UnityEngine.Serialization;

[RequireComponent(typeof(Collider))]
public class TargetDetector : MonoBehaviour
{
    [FormerlySerializedAs("LayersToDetect")]
    public LayerMask LayerToDetect;
    [TagField, SerializeField] private string[] _tags;
    [SerializeField] private BrainAgent _agent;
    private List<Transform> _targets;

    private void Awake()
    {
        _targets = new List<Transform>();
        if(_agent == null)
        {
            _agent = GetComponentInParent<BrainAgent>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_agent == null) return;
        if((LayerToDetect & (1<<other.gameObject.layer)) != 0)
        {
            foreach(string tag in _tags)
            {
                if (other.gameObject.CompareTag(tag))
                {
                    Debug.Log("New target found");
                    if (!_targets.Contains(other.transform))
                    {
                        _targets.Add(other.transform);
                    }
                }
            }
        }
    }
    private void LateUpdate()
    {
        UpdateTarget();
    }
    private void UpdateTarget()
    {
        if(_targets.Count == 0)
        {
            _agent.SetTarget(null);
        }
        else
        {
            Transform nearest = null;
            float nearestDistance = Mathf.Infinity;
            List<Transform> toRemove = new List<Transform>();
            foreach(Transform target in _targets)
            {
                if(target == null)
                {
                    toRemove.Add(target);
                    continue;
                }
                float targetDistance = Mathf.Sign(Vector3.Distance(_agent.transform.position, target.transform.position));
                if (targetDistance < nearestDistance)
                {
                    nearestDistance = targetDistance;
                    nearest = target;
                }
            }
            if(toRemove.Count > 0)
            {
                foreach (Transform target in toRemove)
                {
                    _targets.Remove(target);
                }
            }
            _agent.SetTarget(nearest);
        }
    }
}
