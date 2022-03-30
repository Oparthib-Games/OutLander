using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerScript_03 : MonoBehaviour {
    public GameObject movePlartform_04;
    public GameObject movePlartform_04_target;

    void Start()
    {
        movePlartform_04 = GameObject.Find("movePlartform_04");
        movePlartform_04_target = GameObject.Find("movePlartform_04_target");
    }

    void Update()
    {
        movePlartform_04.transform.position = Vector3.MoveTowards(movePlartform_04.transform.position, movePlartform_04_target.transform.position, 0.5f * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(transform.position, new Vector2(1f, 1f));
    }

}

