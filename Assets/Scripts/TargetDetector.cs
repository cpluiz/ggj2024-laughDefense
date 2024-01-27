using UnityEngine;
using Cinemachine;
using System.Collections.Generic;

[RequireComponent(typeof(Collider))]
public class TargetDetector : MonoBehaviour
{
    [SerializeField]
    private LayerMask _layersToDetect;
    [TagField, SerializeField] private string[] _tags;
    [SerializeField] private NavegationAgent _agent;
    private List<GameObject> _targets;

    private void Awake()
    {
        _targets = new List<GameObject>();
        if(_agent == null)
        {
            _agent = GetComponentInParent<NavegationAgent>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_agent == null) return;
        if((_layersToDetect & (1<<other.gameObject.layer)) != 0)
        {
            foreach(string  tag in _tags)
            {
                if (other.gameObject.CompareTag(tag))
                {
                    Debug.Log("New target found");
                    if (!_targets.Contains(other.gameObject))
                    {
                        _targets.Add(other.gameObject);
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
            GameObject nearest = null;
            float nearestDistance = Mathf.Infinity;
            foreach(GameObject target in _targets)
            {
                if(target == null)
                {
                    _targets.Remove(target);
                    continue;
                }
                float targetDistance = Mathf.Sign(Vector3.Distance(_agent.transform.position, target.transform.position));
                if (targetDistance < nearestDistance)
                {
                    nearestDistance = targetDistance;
                    nearest = target;
                }
            }
            _agent.SetTarget(nearest.transform);
        }
    }
}
