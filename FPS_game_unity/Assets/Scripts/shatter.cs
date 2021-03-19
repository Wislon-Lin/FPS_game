using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shatter : MonoBehaviour
{
    public GameObject destroyedObject;
	public float health = 80;

	public void damage(float amount)
	{
		health -= amount;
		if (health <= 0)
			destruction ();
	}

	public void destruction ()
    {
        Instantiate(destroyedObject, transform.position, transform.rotation);
        Destroy(gameObject);
	}
}
