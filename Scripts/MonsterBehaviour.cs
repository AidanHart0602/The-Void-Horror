using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MonsterBehaviour : MonoBehaviour
{
    private enum AIState
    {
        Walking,
        Attack
    }
    [SerializeField]
    private float _speed;
    private Vector3 _target;
    private AIState _currentState;
    private bool _isAttacking;
    private Vector3 _currentWayPoint;
    private NavMeshAgent _agent;
    [SerializeField] private GameObject[] _wayPoints;
    // Start is called before the first frame update
    void Start()
    {
        _speed = 4;
        _agent = GetComponent<NavMeshAgent>();
        SetDestination();
    }

    // Update is called once per frame
    void Update()
    {
        switch (_currentState)
        {
            case AIState.Walking:
                if (_isAttacking == false)
                {
                    _speed = 4;
                    Movement();
                }
                break;
            case AIState.Attack:

                if(_isAttacking == true) 
                {
                    _speed = 8;
                    Chase();
                }
                break;
        }
    }
    void Movement()
    {
        if (_agent.remainingDistance < 0.1f)
        {
            _currentWayPoint = _wayPoints[Random.Range(0, _wayPoints.Length)].transform.position;
            SetDestination();
        }
    }

    void Chase()
    {
        _currentWayPoint = _target;
        SetDestination();
    }
    void SetDestination()
    {
        _agent.speed = _speed;
        _agent.destination = _currentWayPoint;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _target = other.GetComponent<Transform>().position;
            _isAttacking = true;
            _currentState = AIState.Attack;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(EndAttack());
        }
    }
    IEnumerator EndAttack()
    {
        yield return new WaitForSeconds(5.0f);
        _isAttacking = false;
        _currentState = AIState.Walking;
    }
}
