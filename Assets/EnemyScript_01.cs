using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript_01 : MonoBehaviour {

    bool MovingLeft = false;
    public GameObject EnemyProjectile;
    public float EnemyHealth;
    public GameObject Spawner;
    public Vector3 offset = new Vector3(0f, -1f, 0f);
    public Vector2 projectileVelocity;
    public Sprite[] Damage;


    void Update () {

        if (MovingLeft)
        {
            transform.position += new Vector3(-5f * Time.deltaTime, 0f, 0f);
        }
        else
        {
            transform.position += new Vector3(5f * Time.deltaTime, 0f, 0f);
        }

        if(Random.value > 0.94f)
        {
            PerformEnemyFire();
        }
        
	}

    void PerformEnemyFire()
    {
        GameObject EnemyProjectileAsGameObject = Instantiate(EnemyProjectile, transform.position + offset, Quaternion.identity) as GameObject;

        EnemyProjectileAsGameObject.GetComponent<Rigidbody2D>().velocity = projectileVelocity;
    }

    public void OnTriggerEnter2D(Collider2D collisionWithMoveOpposite)
    {
        obstacleDamageScript accessToObstacleDamage = collisionWithMoveOpposite.gameObject.GetComponent<obstacleDamageScript>();

        if (collisionWithMoveOpposite.tag == "MoveOppositeLeftPiller")
        {
            MovingLeft = false;
        }
        else if (collisionWithMoveOpposite.tag == "MoveOppositeRightPiller")
        {
            MovingLeft = true;
        }

        if (collisionWithMoveOpposite.tag == "SmallBomb")
        {
            EnemyHealth -= accessToObstacleDamage.PerformDamage();
            //print(EnemyHealth);
        }

        if(EnemyHealth <= 0)
        {
            Instantiate(Spawner, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if(EnemyHealth <= 70)
        {
            GetComponent<SpriteRenderer>().sprite = Damage[0];
        }
        if (EnemyHealth <= 50)
        {
            GetComponent<SpriteRenderer>().sprite = Damage[1];
        }
        if (EnemyHealth <= 30)
        {
            GetComponent<SpriteRenderer>().sprite = Damage[2];
        }
    }
}
