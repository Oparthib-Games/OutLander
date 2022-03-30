using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballsProjectileBehaviour : MonoBehaviour {

    public float destroyCount = 1;
    public GameObject MissileParticle;

    void Start () {
		
	}
	

	void Update () {
        destroyCount += 1;

        if (destroyCount > 50)
        {
            Instantiate(MissileParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
	}
}
