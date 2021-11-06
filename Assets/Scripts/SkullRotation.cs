using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullRotation : MonoBehaviour
{
    private float speed = 10.0f;
    // Update is called once per frame
    void Update()
    {
       // transform.Rotate(Vector3.up, speed * Time.deltaTime, Space.Self);

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
           SmoothLookAt(other.gameObject.transform.position - transform.position);
        }
    }
    void SmoothLookAt(Vector3 newDirection)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(newDirection), Time.deltaTime * speed);
    }
}

