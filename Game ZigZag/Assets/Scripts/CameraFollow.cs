using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform objective;
    private Vector3 difference;

    private void Awake()
    {
        difference = transform.position - objective.position;
    }

    private void LateUpdate()
    {
        transform.position = objective.position + difference;
    }
}
