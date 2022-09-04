using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;

    float dst;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dst = offset.magnitude;
        transform.position = target.position - offset * dst;
        transform.LookAt(target);
    }
}
