using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShot : MonoBehaviour
{
    public GameObject prefabDoTiro;
    public void Fire()
    {
        Instantiate(prefabDoTiro, transform.position, transform.rotation);
    }
}
