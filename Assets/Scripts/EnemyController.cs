using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject target;

    public int vida = 10;

    public float velocity = 0.01f;

    private void Start()
    {
        target = GameObject.FindWithTag("Player");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 step = target.transform.position - transform.position;
            transform.position += step * velocity * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            Destroy(collision.gameObject);
    }
}
