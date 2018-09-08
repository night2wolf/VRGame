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
