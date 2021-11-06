using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoDeTiro : MonoBehaviour
{
    public float lifeTime = 3;

    public float velocity = 0.1f;

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
        if (gameObject.name == "RocketEmpty(Clone)" && collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }    
        if (gameObject.name == "TeletransporteBullet(Clone)" && collision.gameObject.tag == "Parede")
        {
            
            // o player faz o tp pra esse local
        }
        
    }
}
