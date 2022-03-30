using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript_1 : MonoBehaviour {

    public GameObject EnemyPrefab_01;


    void OnTriggerEnter2D(Collider2D collisionForSpawnEnemy)
    {
        if (collisionForSpawnEnemy.name == "Player")
        {
            Instantiate(EnemyPrefab_01, transform.position - new Vector3(-2f, 0f), Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector2(1f, 5f));
    }

}
