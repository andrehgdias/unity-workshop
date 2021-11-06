using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunController : MonoBehaviour
{

    public GameObject gunPoint;

    private Animator myAnimator;

    public float fireRate = 4;

    float fireTimer;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;

      

    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("Player"))
        {
            
            if (fireTimer > fireRate)
            {
                fireTimer = 0;

                gunPoint.GetComponent<FireShot>().Fire();

                myAnimator.SetBool("EstouAtirando", true);

            }
            myAnimator.SetBool("EstouAtirando", false);
        }
    }
}
