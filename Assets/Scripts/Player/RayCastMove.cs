using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastMove : MonoBehaviour
{

    public float range = 5f;

    void Start()
    {
        
    }
    // Start is called before the first frame update
    void Update()
    {

    }

    public bool CanMove(Vector3 direction)
    {
        Ray theRay = new Ray(transform.position, transform.TransformDirection(direction * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(direction * range));

        if (Physics.Raycast(theRay, out RaycastHit hit, range))
        {
            if (hit.collider.tag == "Environment")
            {
                return false;
            }
            else if (hit.collider.tag == "Enemy")
            {
                return false;
            }
        }
        return true;
    }
}