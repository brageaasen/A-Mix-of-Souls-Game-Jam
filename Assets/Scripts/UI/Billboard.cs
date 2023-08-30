using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private Transform cam;

    // Makes local transform follow camera like a billboard
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
