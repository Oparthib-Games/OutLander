using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {
    public GameObject MovingPlartform_02;
    public GameObject MovingPlartform_02_target;
    GameObject Player;

    void Start()
    {
        MovingPlartform_02 = GameObject.Find("MovingPlartform_02");
        MovingPlartform_02_target = GameObject.Find("MovingPlartformTarget_02");
        Player = GameObject.Find("Player");
        Player.GetComponent<OutLanderScript>().cancelInvokeFunction();
    }

    void Update()
    {
        MovingPlartform_02.transform.position = Vector3.MoveTowards(MovingPlartform_02.transform.position, MovingPlartform_02_target.transform.position, 0.5f * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector2(1f, 1f));
    }

}
