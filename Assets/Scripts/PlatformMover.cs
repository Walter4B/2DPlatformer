using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    public GameObject PlatformPrefab;
    public float MovementSpeed = 5.0f;
    public float WaitAtWaypointTime = 2.0f;
    public bool ShouldLoop = true;

    public List<Transform> Waypoints;

    private Transform _platform;
    private int _waypointIndex = 0;
    private float _timer = 0.0f;
    private bool _shouldMove = true;

    void Awake()
    {
        _platform = Instantiate (PlatformPrefab, transform.position, Quaternion.identity, transform).transform;
        _platform.tag = "MovingPlatform";
    }

    void Update()
    {
        if (Time.time >= _timer && _shouldMove)
        {
            MovePlatform();
        }
    }
    private void MovePlatform()
    {
        if (Waypoints.Count == 0)
            return;

        _platform.position = Vector3.MoveTowards(_platform.position, Waypoints[_waypointIndex].position, MovementSpeed * Time.deltaTime);

        if (Vector3.Distance(_platform.position, Waypoints[_waypointIndex].position) <= 0.0f)
        {
            _waypointIndex++;
            _timer = Time.time + WaitAtWaypointTime;
        }
        if (_waypointIndex >= Waypoints.Count)
        {
            if (ShouldLoop)
                _waypointIndex = 0;
            else
                _shouldMove = false;
        }
    }
}
