using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestroyerScript : MonoBehaviour {

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector2(40f, 1f));
    }

    void OnCollisionEnter2D(Collision2D collisionWithProjectile)
    {
        Destroy(collisionWithProjectile.gameObject);
    }


}
