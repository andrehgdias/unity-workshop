using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoDeTiro : MonoBehaviour
{
    [SerializeField] private float lifeTime = 3;
    [SerializeField] private float velocity = 10f;
    
    private GameObject player;
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;

        if(lifeTime <= 0)
            Destroy(gameObject);

        rb.AddForce(gameObject.transform.forward * velocity, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collison");
        Debug.Log(collision.gameObject.name);

        if (gameObject.name == "RocketEmpty(Clone)" && collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (gameObject.name == "TeletransporteBullet(Clone)" && collision.gameObject.CompareTag("Parede"))
        {
            GameObject teleportPoint = gameObject.transform.GetChild(0).gameObject;
            Vector3 movement = teleportPoint.transform.position - player.transform.position;

            player.layer = LayerMask.NameToLayer("NoColision");
            player.GetComponent<FirstPersonController>().moveDirection.y = 0;
            player.GetComponent<CharacterController>().Move(movement);
            player.layer = LayerMask.NameToLayer("Default");

            Destroy(gameObject);
        }
        else if (gameObject.name == "TeletransporteBullet(Clone)" && collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else
            Destroy(gameObject);
    }
}
