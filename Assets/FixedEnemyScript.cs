using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedEnemyScript : MonoBehaviour {
    public GameObject RedEnemyProjectile;
    public float velocityaxisX, velocityaxisY;
	
	void Update () {
		if(Random.value > 0.9f)
        {
            PerformFixedEnemyFire();
        }
	}
    void PerformFixedEnemyFire()
    {
        GameObject RedEnemyProjectileAsGO = Instantiate(RedEnemyProjectile, transform.position, Quaternion.identity) as GameObject;
        RedEnemyProjectileAsGO.GetComponent<Rigidbody2D>().velocity = new Vector2(velocityaxisX, -velocityaxisY);
    }
}
