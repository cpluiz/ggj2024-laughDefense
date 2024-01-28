using System.Collections.Generic;
using UnityEngine;

public class Neurotransmiter : BrainAgent
{
    private NeurotransmiterDescriptor _descriptor;
    private List<Enemy> _enemyTakingDamage;
    private List<Enemy> _enemyTakingIncreasedDamage;
    new protected void Awake()
    {
        base.Awake();
        _enemyTakingDamage = new List<Enemy>();
        _enemyTakingIncreasedDamage = new List<Enemy>();
    }

    public void SetNeurotransmiterValues(NeurotransmiterDescriptor descriptor, Transform destination)
    {
        _descriptor = descriptor;
        SetDestination(destination);
        _maxLife = descriptor.Life;
        _currentLife = descriptor.Life;
        _agent.speed = descriptor.WalkingSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((_targetDetector.LayerToDetect & (1 << collision.gameObject.layer)) != 0)
        {
            bool bonusDammage = false;
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            foreach (string tag in _descriptor.StrongAgainst)
            {
                bonusDammage &= enemy.CompareTag(tag);
            }

            if (_enemyTakingIncreasedDamage.Contains(enemy) || _enemyTakingDamage.Contains(enemy))
            {
                return;
            }
            if (bonusDammage)
            {
                _enemyTakingIncreasedDamage.Add(enemy);
            }
            else
            {
                _enemyTakingDamage.Add(enemy);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if ((_targetDetector.LayerToDetect & (1 << collision.gameObject.layer)) != 0)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (_enemyTakingDamage.Contains(enemy))
            {
                _enemyTakingDamage.Remove(enemy);
            }
            if (_enemyTakingIncreasedDamage.Contains(enemy))
            {
                _enemyTakingIncreasedDamage.Remove(enemy);
            }
        }
    }
}
