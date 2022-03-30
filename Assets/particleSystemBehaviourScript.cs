using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleSystemBehaviourScript : MonoBehaviour {

    float StartCountingDestroyng = 1;

	void LateUpdate () {
        StartCountingDestroyng += 1;
        if(StartCountingDestroyng > 10)
        {
            Destroy(gameObject);
        }
	}
}
