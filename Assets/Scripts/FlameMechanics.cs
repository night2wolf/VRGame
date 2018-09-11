using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class FlameMechanics : MonoBehaviour 
{
	public GameObject FlameObject;
	public float FlameVelocityLimit;
	public VRTK_ControllerEvents ControllerEvents;
	public bool FlameStatus;
	Rigidbody playerHand;

	void Start () 
	{
		//ControllerEvents.SubscribeToButtonAliasEvent(VRTK_ControllerEvents.ButtonAlias.TriggerClick, false, maintainFlame);
		ControllerEvents.TriggerPressed += new ControllerInteractionEventHandler(getFlameStatus);
		ControllerEvents.TriggerReleased += new ControllerInteractionEventHandler(maintainFlame);
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

	void getFlameStatus (object sender, ControllerInteractionEventArgs e)
	{
		Debug.Log("Flame Status Set. Button Pressure: " + e.buttonPressure);
		if (FlameObject.activeSelf && e.buttonPressure <= .5f)
		{
			FlameStatus = true;
		}
	}

	void maintainFlame(object sender, ControllerInteractionEventArgs e)
	{
		Debug.Log("Maintain Flame Attempted. Button Pressure: " + e.buttonPressure);
		if (FlameStatus && e.buttonPressure <= .5f)
		{
			FlameObject.SetActive(true);
		}
	}

}
