using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion_destruction : MonoBehaviour
{
	
    public float delay = 3;
    float count_down;
    public GameObject explosion;
    public float radius = 5;
    public float force = 700;
	void Start ()
    {
        count_down = delay; 
	}
	
	void Update ()
    {
        count_down -= Time.deltaTime;
		if(count_down <= 0) //3s later explosion;
        {
            Instantiate(explosion,transform.position,Quaternion.Euler(-90,0,0)); 
			Collider[] colliders = Physics.OverlapSphere(transform.position,radius); //偵測周圍的碰撞體

			foreach(Collider nearbyObject in colliders) //取得每個被偵測到的碰撞體
            {
                
				shatter sht = nearbyObject.GetComponent<shatter>(); //Get shatter Scripts讓shatter=sht; 
                if (sht != null)
					sht.destruction(); //Trigger Shater scripts destruction
				
            }

			Collider[] colliders_shatter = Physics.OverlapSphere(transform.position, radius);//偵測周圍的碰撞體
			foreach (Collider nearbyObject in colliders) //取得每個被偵測到的碰撞體
            {
                Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
                if (rb != null) //if The obj has rb
					rb.AddExplosionForce(force, transform.position, radius); //give the obj addforce;
            }

            Destroy(gameObject); 
        }
	}
}
