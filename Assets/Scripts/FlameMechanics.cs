using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameMechanics : MonoBehaviour 
{
	public GameObject FlameObject;
	public float FlameVelocityLimit;
	Rigidbody playerHand;

	void Start () 
	{

	}
	
	
	void FixedUpdate () 
	{
		float xVelocity = Mathf.Abs(this.GetComponent<Rigidbody>().velocity.x) * 100000000;
		float zVelocity = Mathf.Abs(this.GetComponent<Rigidbody>().velocity.z) * 100000000;
		float yVelocity = Mathf.Abs(this.GetComponent<Rigidbody>().velocity.y) * 100000000;
		Debug.Log("Magnitude: " + this.GetComponent<Rigidbody>().velocity.magnitude);

		if (this.GetComponent<Rigidbody>().velocity.magnitude >= FlameVelocityLimit) //If the candle moves faster than the limit...
		{
			FlameObject.SetActive(false); //...the candle goes out...
		}

	}


	void OnTriggerEnter(Collider other)
	{
		if (other.name == "Relighter")
		{
			FlameObject.SetActive(true);
		}
	}
}
