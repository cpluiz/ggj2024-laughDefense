using UnityEngine;

public class Enemy : NavegationAgent
{
    new protected void Awake()
    {
        base.Awake();
    }

    public void SetEnemyValues(EnemyDescriptor descriptor, Transform destination)
    {
        gameObject.tag = descriptor.Tag;
        _agent.speed = descriptor.WalkingSpeed;
        _finalTarget = destination;
        _agent.SetDestination(_finalTarget.position);
        TargetDetector targetDetector = GetComponentInChildren<TargetDetector>();
        //TODO set target layer
    }
}
