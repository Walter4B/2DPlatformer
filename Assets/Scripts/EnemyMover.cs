using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public Transform Enemy;
    public float MovementSpeed;
    public List<Transform> Waypoints;
    public bool IsStunned = false;

    private int _waypointIndex = 0;

    private Animator _enemyAnimator;

    private void Awake()
    {
        //TODO: dodat cekanje i implimentirati animacije prema tome.
        _enemyAnimator = Enemy.GetComponent<Animator>();
        _enemyAnimator.SetBool("IsMoving", true);
    }

    private void Update()
    {
        _enemyAnimator.SetBool("IsStunned", IsStunned);
        if(!IsStunned)
            Move();
    }

    private void Flip()
    {
        Vector3 localScale = Enemy.localScale;
        localScale.x *= -1.0f;

        Enemy.localScale = localScale;
    }

    private void Move()
    {
        if(Waypoints.Count != 0)
        {
            Enemy.position = Vector3.MoveTowards(Enemy.position, Waypoints[_waypointIndex].position, MovementSpeed * Time.deltaTime);

            if(Vector3.Distance(Enemy.position, Waypoints[_waypointIndex].position) <= 0.1f)
            {
                _waypointIndex++;

                if (_waypointIndex >= Waypoints.Count)
                    _waypointIndex = 0;

                Flip();
            }
        }
    }
}
