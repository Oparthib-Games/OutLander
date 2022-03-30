using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballsFallerTriggerScript : MonoBehaviour {

    GameObject ballsFaller;

    void OnTriggerEnter2D(Collider2D triggered)
    {
       if(triggered.name == "Player")
        {
            Destroy(GameObject.Find("BallsFaller"));
        } 
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector2(1f, 10f));
    }
}
