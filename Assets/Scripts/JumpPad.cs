using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float jumpForce = 15f;
    private GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
            player.GetComponent<FirstPersonController>().moveDirection.y = jumpForce * gameObject.transform.up.y;
        }
    }
}
