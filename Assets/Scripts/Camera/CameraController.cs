using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _smoothness;
    private Vector3 _targetPosition, _newPosition;
    public Vector3 minPos, maxPos;

    void LateUpdate()
    {
        if (transform.position != _player.position)
        {
            _targetPosition = _player.position;

            Vector3 cameraBoundaryPosition = new Vector3(
                Mathf.Clamp(_targetPosition.x, minPos.x, maxPos.x),
                Mathf.Clamp(_targetPosition.y, minPos.y, maxPos.y),
                Mathf.Clamp(_targetPosition.z, minPos.z, maxPos.z)
            );

            _newPosition = Vector3.Lerp(transform.position, cameraBoundaryPosition, _smoothness);
            transform.position = _newPosition;
        }
    }
}
