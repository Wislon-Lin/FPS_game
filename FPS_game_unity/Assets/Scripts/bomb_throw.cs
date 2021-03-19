using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb_throw : MonoBehaviour
{
    public float force = 20;
    public GameObject bomb;

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            GameObject obj = Instantiate(bomb,transform.position,transform.rotation); //Instance bomb
            Rigidbody rb = obj.GetComponent<Rigidbody>();  //Get this obj.rb
            rb.AddForce(transform.forward*force,ForceMode.VelocityChange); //Add one Force
        }
	}
}
