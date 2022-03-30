using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBehaviour : MonoBehaviour {

    public GameObject MissileParticle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(MissileParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
