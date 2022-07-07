using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using System;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent), typeof(InteractableObject))]
public class Unit : MonoBehaviour, IHaveHealth
{
    private UnitState state;

    public static Unit ActiveUnit;

    public IHaveHealth Target { get; set; }

    public Camp camp;
    public NavMeshAgent agent;
    public event Action OnDied;
    public event Action OnTargetSet;

    public Animator animator;

    [SerializeField] private float _health;
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;

    public float hitDistance;
    public float duration;

    [SerializeField] private AudioSource _audioHit;


    public readonly string IDLE = "idle";
    public readonly string WALK = "walk";
    public readonly string ATTACK = "attack";
    public readonly string DIE = "die";

    private float _attackTime;
    private float _currentHealth;

    public UnitState currentState;
    public UnitStateFighting fightingState;
    public UnitStateWalking walkingState;

    private void Start()
    {
        fightingState = new UnitStateFighting(this);
        walkingState = new UnitStateWalking(this);

        Target = FindEnemyCastle();

        currentState = walkingState;
        currentState.Enter();

        _currentHealth = _health;

        agent.speed = _speed;
    }

    public void ChangeState(UnitState state)
    {
        currentState.Exit();
        currentState = state;
        currentState.Enter();
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
            Die();
    }

    public Transform ReturnTransform()
    {
        return transform;
    }

    public GameObject ReturnGameObject()
    {
        return gameObject;
    }

    public void SetNewTarget(IHaveHealth target)
    {
        Target = target;
        Target.OnDied += SetDefaultTarget;

        agent.speed = _speed * 1.4f;
    }

    public void SetDefaultTarget()
    {
        Target = FindEnemyCastle();
        
        if(agent != null)
            agent.speed = _speed;
    }

    public void Die()
    {
        OnDied?.Invoke();

        Destroy(gameObject);
    }

    public void Attack()
    {
        animator.SetTrigger(ATTACK);
    }

    private IHaveHealth FindEnemyCastle()
    {
        var castles = FindObjectsOfType<Castle>();

        foreach(var castle in castles)
        {
            if(castle.camp != camp)
            {
                return castle;
            }
        }

        return null;
    }

    private void FixedUpdate()
    {
        currentState.Update();
    }

    public void HitTarget()
    {
        Debug.Log("Hit");
        _audioHit.Play();
        Target.TakeDamage(_damage);
    }

    public void ProvokeTarget()
    {
        var target = Target.ReturnGameObject().GetComponent<Unit>();

        if (target != null)
        {
            target.SetNewTarget(this);
        }
    }
}
