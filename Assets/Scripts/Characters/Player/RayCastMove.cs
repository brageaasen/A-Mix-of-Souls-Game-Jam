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
        LookingAt();
    }

    public bool CanMove(Vector3 direction)
    {
        Ray theRay = new Ray(transform.position, transform.TransformDirection(direction * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(direction * range));

        if (Physics.Raycast(theRay, out RaycastHit hit, range))
        {
            if (hit.collider.tag == "Environment" || hit.collider.tag == "Enemy" || hit.collider.tag == "Angel"
                || hit.collider.tag == "Door" || hit.collider.tag == "Chest")
                return false;
        }
        return true;
    }

    public string LookingAt()
    {
        Ray theRay = new Ray(transform.position, transform.TransformDirection(Vector3.forward * range * 2));
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward * range * 2));
        
        if (Physics.Raycast(theRay, out RaycastHit hit, range * 2))
        {
            if (hit.collider.tag != null)
                return hit.collider.tag;
        }
        return "";
    }

    public GameObject LookingAtGameObject()
    {
        Ray theRay = new Ray(transform.position, transform.TransformDirection(Vector3.forward * range * 2));
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward * range * 2));
        
        if (Physics.Raycast(theRay, out RaycastHit hit, range * 2))
        {
            return hit.collider.gameObject;
        }
        return hit.collider.gameObject;
    }
}