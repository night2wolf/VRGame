using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Telekinesis : MonoBehaviour 
{
	GameObject grabbedObject;
	public VRTK_Pointer Pointer;
	public VRTK_ControllerEvents Controller;
	public VRTK_StraightPointerRenderer Beam;
	Vector2 thumbPosition;

	void Start () 
	{
		Pointer.ActivationButtonPressed += new ControllerInteractionEventHandler(findObject);
	}
	
	
	void Update () 
	{
		if (grabbedObject != null)
		{
			try
			{
				thumbPosition = Controller.GetTouchpadAxis();
				Debug.Log("Thumb Position: " + thumbPosition.x + ", " + thumbPosition.y);
			}
			catch (System.Exception)
			{
				Debug.Log("Couldn't retrieve thumb position.");
			}
			
			if (thumbPosition.y > 0)
			{
				var Direction = (grabbedObject.transform.position - Beam.transform.parent.transform.position).normalized;
				Vector3.MoveTowards(grabbedObject.transform.position, -Direction, 12f);
				Debug.Log("Moving Forward");
			}
			if (thumbPosition.y < 0)
			{
				Vector3.MoveTowards(grabbedObject.transform.position, Beam.transform.parent.transform.position, 12f);
				Debug.Log("Moving Backward");
			}

		}

	}

	void findObject (object sender, ControllerInteractionEventArgs e)
	{
		if (Beam.playareaCursor.validLocationObject == null)
		{
			return;
		}
		if (Beam.playareaCursor.validLocationObject != null)
		{
			grabbedObject = Beam.playareaCursor.validLocationObject;
			Debug.Log("Object Grabbed: " + Beam.playareaCursor.validLocationObject.name);
		}
		else
		{
			grabbedObject = null;
		}
	}

}
