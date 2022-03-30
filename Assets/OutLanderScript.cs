using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OutLanderScript : MonoBehaviour {

    public float PlayerHealth = 100;
    public GameObject PlayerProjectile;
    public float firingRate;
    private bool facingRight = true;
    public float scaleX;
    public float jumpForceX;
    public float jumpForceY;
    public float lifeAmount;

    public GameObject scoreUiText;
    Text textComponent;
    public GameObject lVlmanager;


    public GameObject MovingPlartformTarget;
    public GameObject MovingPlartform;
    private bool movePlartform = false;


    Quaternion downRotationRight;
    Quaternion downRotationLeft;
    Quaternion forwardRotationRight;
    Quaternion forwardRotationLeft;

    void Start () {
        downRotationRight = Quaternion.Euler(0, 0, -35);
        downRotationLeft = Quaternion.Euler(0, 0, 35);
        forwardRotationRight = Quaternion.Euler(0, 0, 15);
        forwardRotationLeft = Quaternion.Euler(0, 0, -15);

        textComponent = scoreUiText.GetComponent<Text>();
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.E))
        {
            JumpRight();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            JumpLeft();
        }

        if (facingRight)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, downRotationRight, 3f * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, downRotationLeft, 3f * Time.deltaTime);
        }
        if (movePlartform)
        {
            MovingPlartform.transform.position = Vector3.MoveTowards(MovingPlartform.transform.position, MovingPlartformTarget.transform.position, 5f * Time.deltaTime);
        }

        textComponent.text = PlayerHealth.ToString();
        if (PlayerHealth <= 40)
        {
            textComponent.color = Color.red;
        }
    }

    public void JumpRight()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(jumpForceX , jumpForceY );
        transform.localScale = new Vector3(scaleX, transform.localScale.y, 0f);

        transform.rotation = forwardRotationRight;
        facingRight = true;
    }
    public void JumpLeft()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-jumpForceX , jumpForceY );
        transform.localScale = new Vector3(-scaleX, transform.localScale.y, 0f);

        transform.rotation = forwardRotationLeft;
        facingRight = false;
    }

    public void OnTriggerEnter2D(Collider2D collisionWithSomething)
    {
        obstacleDamageScript GetAccessToObstacleScript = collisionWithSomething.gameObject.GetComponent<obstacleDamageScript>();
        if(collisionWithSomething.tag == "Threat")
        {
            PlayerHealth -= GetAccessToObstacleScript.PerformDamage();
            print(PlayerHealth);
        }
        if(PlayerHealth <= 0)
        {
            lVlmanager.GetComponent<LevelManagerScript>().loadLevelFunction("LoseScreen");
        }

        if(collisionWithSomething.tag == "EnemySpawnerTrigger")
        {
            InvokeRepeating("StartFiring", 2f, firingRate);
            movePlartform = true;
        }

        if(collisionWithSomething.tag == "life")
        {
            PlayerHealth += lifeAmount;
            textComponent.color = Color.white;
            Destroy(collisionWithSomething.gameObject);
        }

        if(collisionWithSomething.name == "WinObject")
        {
            lVlmanager.GetComponent<LevelManagerScript>().loadLevelFunction("WinScreen");
        }
    }

    public void cancelInvokeFunction()
    {
        CancelInvoke("StartFiring");
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        obstacleDamageScript GetAccessToObstacleScript = col.gameObject.GetComponent<obstacleDamageScript>();
        if (col.gameObject.tag == "Threat")
        {
            PlayerHealth -= GetAccessToObstacleScript.PerformDamage();
            print(PlayerHealth);
        }
        if (PlayerHealth <= 0)
        {
            lVlmanager.GetComponent<LevelManagerScript>().loadLevelFunction("LoseScreen");
        }
    }

    void StartFiring()
    {
        GameObject PlayerProjectileAsGameObject = Instantiate(PlayerProjectile, transform.position, Quaternion.identity) as GameObject;
        PlayerProjectileAsGameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 10f);
    }


}
