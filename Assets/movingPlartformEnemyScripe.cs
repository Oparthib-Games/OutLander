using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlartformEnemyScripe : MonoBehaviour {

    bool movingUp = false;
	
	void Update () {
        if (movingUp)
        {
            transform.position += new Vector3(0f, 2f * Time.deltaTime, 0f);
        }
        else if (!movingUp)
        {
            transform.position += new Vector3(0f, -2f * Time.deltaTime, 0f);
        }
		
	}

    public void OnTriggerEnter2D(Collider2D Trig)
    {
        if(Trig.tag == "MoveOppositeEmptyUp")
        {
            movingUp = false;
        }
        else if(Trig.tag == "MoveOppositeEmptyDown")
        {
            movingUp = true;
        }
    }
}
