using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform Player;

    private Transform _transform;

    void Awake()
    {
        _transform = transform;
    }

    void Update()
    {
        Vector3 newPosition = new Vector3(Player.position.x, Player.position.y, _transform.position.z);

        _transform.position = newPosition;
    }
}
