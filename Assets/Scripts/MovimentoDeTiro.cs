using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoDeTiro : MonoBehaviour
{
    public float lifeTime = 3;
    public GameObject player;
    public float velocity = 0.1f;



    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;

        if(lifeTime <= 0)
        {
            Destroy(gameObject);
        }

        gameObject.transform.position += gameObject.transform.forward * velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(gameObject.name);
        Debug.Log(collision.gameObject.tag);
        Debug.Log(player.name);
        if (gameObject.name == "RocketEmpty(Clone)" && collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }    
        if (gameObject.name == "TeletransporteBullet(Clone)" && collision.gameObject.tag == "Parede")
        {
            Debug.Log("acertei uma parede");
            player.transform.position = gameObject.transform.GetChild(0).gameObject.transform.position;
            Destroy(gameObject);
            // o player faz o tp pra esse local
        }
        
    }
}
