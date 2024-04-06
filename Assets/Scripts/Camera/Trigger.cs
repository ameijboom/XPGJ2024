using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Vector3 cameraPosition;
    public Vector3 playerPosition;

    private CameraController _cameraController;

    void Start()
    {
        _cameraController = Camera.main.GetComponent<CameraController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _cameraController.minPos += cameraPosition;
            _cameraController.maxPos += cameraPosition;

            other.transform.position = playerPosition;
        }
    }
}
