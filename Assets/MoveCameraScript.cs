using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraScript : MonoBehaviour {
    public GameObject TargetGameObject;
	
	void LateUpdate () {
        transform.position = new Vector3(TargetGameObject.transform.position.x, transform.position.y, transform.position.z);
	}
}
