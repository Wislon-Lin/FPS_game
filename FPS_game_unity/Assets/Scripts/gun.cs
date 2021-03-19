using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class gun : MonoBehaviour
{
	public GameObject muzzle_fire;
	public float range = 30;
	public Camera mainCam;
	public GameObject shot_smoke;
	public GameObject bullet_hole;
	public float force = 40; 
	public float fire_rate = 10;
	float nexttime_to_fire = 0; 
	public float hurt = 10;

	void Update()
	{
		if (Input.GetKey (KeyCode.Mouse0) && Time.time >= nexttime_to_fire)
		{
			nexttime_to_fire = Time.time + 1 / fire_rate;
			GameObject obj1 = GameObject.Find ("Muzzle");
			Instantiate (muzzle_fire,obj1.transform.position
				,obj1.transform.rotation, obj1.transform);
			RaycastHit hit;
			if (Physics.Raycast (mainCam.transform.position, mainCam.transform.forward, out hit, range))
			{
				Debug.Log (hit.transform.name);
				Instantiate(shot_smoke,hit.point,Quaternion.LookRotation(hit.normal));
				if (hit.transform.tag != "unattachable") 
				{
					GameObject obj2 = Instantiate (bullet_hole, hit.point + hit.normal * 0.05f,
						                 Quaternion.LookRotation (hit.normal));
					obj2.transform.parent = hit.transform;
				}
				if (hit.rigidbody != null)
					hit.rigidbody.AddForce (-hit.normal*force); 
				shatter sht = hit.transform.GetComponent<shatter> ();
				if (sht != null)
					sht.damage (hurt); 
			} 
		}
	}
}
