using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class BrainAgent : MonoBehaviour
{
    [SerializeField] protected NavMeshAgent _agent;
    [SerializeField] protected Transform _finalTarget;
    [SerializeField] protected Transform _currentTarget;

    protected float _maxLife;
    protected float _currentLife;
    protected TargetDetector _targetDetector;
    public float LifePerncentage01
    {
        get
        {
            return Mathf.Clamp01(_currentLife /  _maxLife);
        }
    }

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
        _targetDetector = GetComponentInChildren<TargetDetector>();
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

    public void TakeDammage(float dammage)
    {
        _currentLife -= dammage;
        //TODO improve this thing
        if( _currentLife <= 0)
        {
            Destroy(gameObject);
        }
    }
}
