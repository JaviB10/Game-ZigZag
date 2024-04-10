using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotationSpeed = 200f; // Velocidad de rotación en grados por segundo

    void Update()
    {
        // Rotar el objeto alrededor del eje Y (vertical) en el tiempo actual
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
