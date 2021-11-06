using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    public GameObject gameEnemySpawner;
    private void OnTriggerEnter(Collider other)
    {
        gameEnemySpawner.GetComponent<EnemySpawner>().SpawnEnemy();
    }
}
