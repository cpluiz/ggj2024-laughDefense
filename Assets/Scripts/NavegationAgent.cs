using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavegationAgent : MonoBehaviour
{
    [SerializeField] protected NavMeshAgent _agent;
    [SerializeField] protected Transform _finalTarget;
    [SerializeField] protected Transform _currentTarget;

    protected void Awake()
    {
        SetupAgent();
    }
    protected void LateUpdate()
    {
        FollowTarget();
    }
    protected void SetupAgent()
    {
        if(_agent == null)
        {
            _agent = GetComponent<NavMeshAgent>();
        }
    }
    protected void FollowTarget()
    {
        if(_currentTarget == null && _finalTarget != null)
        {
            _currentTarget = _finalTarget;
        }
        if(_currentTarget != null)
        {
            _agent.SetDestination(_currentTarget.position);
        }
    }
    public void SetDestination(Transform destination)
    {
        _finalTarget = destination;
    }
    public void SetTarget(Transform target)
    {
        _currentTarget = target;
    }
}
