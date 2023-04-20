using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cam;

    // Make local transform follow camera
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
