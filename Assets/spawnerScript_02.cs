using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerScript_02 : MonoBehaviour {
    public GameObject movePlartform_03;
    public GameObject movePlartform_03_target;

    void Start()
    {
        movePlartform_03 = GameObject.Find("movePlartform_03");
        movePlartform_03_target = GameObject.Find("movePlartform_03_target");
    }

    void Update()
    {
        movePlartform_03.transform.position = Vector3.MoveTowards(movePlartform_03.transform.position, movePlartform_03_target.transform.position, 0.5f * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(transform.position, new Vector2(1f, 1f));
    }

}
