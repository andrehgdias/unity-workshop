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
        Debug.Log(collision.gameObject.tag);
        if (this.gameObject.name == "RocketEmpty" && collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }    
        if (this.gameObject.name == "TeletransporteBullet" && collision.gameObject.tag == "Parede")
        {
            // o player faz o tp pra esse local
        }
        
    }
}
