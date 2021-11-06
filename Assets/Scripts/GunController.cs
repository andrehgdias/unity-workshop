using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject prefabDoTiro;

    public Animator myAnimator;

    public float fireRate = 1;

    float fireTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;

        myAnimator.SetBool("EstouAtirando", false);

        if (fireTimer > fireRate)
        {
            if (Input.GetMouseButton(0))
            {
                fireTimer = 0;

                Instantiate(prefabDoTiro, gameObject.transform.position, gameObject.transform.rotation);

                myAnimator.SetBool("EstouAtirando", true);
            }
        }
    }
}
