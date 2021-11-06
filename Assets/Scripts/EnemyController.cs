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

    // Update is called once per frame
    void Update()
    {
        Vector3 step = target.transform.position - transform.position;
        transform.position += step * velocity;
    }
}
