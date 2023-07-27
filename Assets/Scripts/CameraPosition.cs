using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public Transform objectsCollider;
    public Transform target;
    void Update()
    {
        transform.position = objectsCollider.position;
        transform.LookAt(target);
    }
}