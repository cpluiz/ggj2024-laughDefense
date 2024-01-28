using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BrainAgent
{
    [TagField, SerializeField] private string[] _strongAgainst;
    private EnemyDescriptor _descriptor;

    private List<Neurotransmiter> _neurotransmiterTakingDamage;
    private List<Neurotransmiter> _neurotransmiterTakingIncreasedDamage;

    private List<Neurotransmiter> _itensToRemove;
    new protected void Awake()
    {
        base.Awake();
        _neurotransmiterTakingDamage = new List<Neurotransmiter>();
        _neurotransmiterTakingIncreasedDamage = new List<Neurotransmiter>();
        _itensToRemove = new List<Neurotransmiter>();
    }
    

    public void SetEnemyValues(EnemyDescriptor descriptor, Transform destination)
    {
        _descriptor = descriptor;
        gameObject.tag = descriptor.Tag;
        _agent.speed = descriptor.WalkingSpeed;
        _finalTarget = destination;
        _agent.SetDestination(_finalTarget.position);
        TargetDetector targetDetector = GetComponentInChildren<TargetDetector>();
        _maxLife = descriptor.Life;
        _currentLife = descriptor.Life;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if((_targetDetector.LayerToDetect & (1<<collision.gameObject.layer)) != 0)
        {
            bool bonusDammage = false;
            Neurotransmiter neurotransmiter = collision.gameObject.GetComponent<Neurotransmiter>();
            foreach (string tag in _descriptor.StrongAgainst)
            {
                bonusDammage &= neurotransmiter.CompareTag(tag);
            }

            if (_neurotransmiterTakingIncreasedDamage.Contains(neurotransmiter) || _neurotransmiterTakingDamage.Contains(neurotransmiter))
            {
                return;
            }
            if (bonusDammage)
            {
                _neurotransmiterTakingIncreasedDamage.Add(neurotransmiter);
            }
            else
            {
                _neurotransmiterTakingDamage.Add(neurotransmiter);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if ((_targetDetector.LayerToDetect & (1 << collision.gameObject.layer)) != 0)
        {
            Neurotransmiter neurotransmiter = collision.gameObject.GetComponent<Neurotransmiter>();
            _itensToRemove.Add(neurotransmiter);
        }
    }
    private void RemoveUnusedOrNullReferences()
    {
        foreach(Neurotransmiter neurotransmiter in _itensToRemove)
        {
            if (_neurotransmiterTakingDamage.Contains(neurotransmiter))
            {
                _neurotransmiterTakingDamage.Remove(neurotransmiter);
            }
            if (_neurotransmiterTakingIncreasedDamage.Contains(neurotransmiter))
            {
                _neurotransmiterTakingIncreasedDamage.Remove(neurotransmiter);
            }
        }
        _itensToRemove.Clear();
    }

    protected new void LateUpdate()
    {
        base.LateUpdate();

        foreach(Neurotransmiter neurotransmiter in _neurotransmiterTakingDamage)
        {
            if(neurotransmiter != null)
            {
                neurotransmiter.TakeDammage(_descriptor.Dammage * Time.deltaTime);
            }
            else
            {
                _itensToRemove.Add(neurotransmiter);
            }
        }
        //TODO Change extra dammage modifier based on a external variable instead of hardcoded
        foreach (Neurotransmiter neurotransmiter in _neurotransmiterTakingIncreasedDamage)
        {
            if (neurotransmiter != null)
            {
                neurotransmiter.TakeDammage(_descriptor.Dammage * Time.deltaTime * 1.3f); //  30% more damage for now
            }
            else
            {
                _itensToRemove.Add(neurotransmiter);
            }
        }
    }
}
