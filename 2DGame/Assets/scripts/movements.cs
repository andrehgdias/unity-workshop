using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movements : MonoBehaviour
{
    public float velocity = 0.1f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position - (transform.right  * velocity);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position - (transform.right * -1 * velocity);
        }
    }
}
