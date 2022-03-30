using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript_2 : MonoBehaviour {

    public GameObject EnemyPrefab_02;
    public GameObject EnemyPrefab_03;
    public Vector3 offset_1;
    public Vector3 offset_2;


    void OnTriggerEnter2D(Collider2D collisionForSpawnEnemy)
    {
        if (collisionForSpawnEnemy.name == "Player")
        {
            Instantiate(EnemyPrefab_02, transform.position + offset_1, Quaternion.identity);
            Instantiate(EnemyPrefab_03, transform.position + offset_2, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector2(1f, 11f));
    }

}
