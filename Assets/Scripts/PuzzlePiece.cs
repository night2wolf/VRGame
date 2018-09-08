﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class PuzzlePiece : MonoBehaviour 
{

	public bool isActivated = false;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "PuzzleTrigger")
		{
			activated();
		}
	}

	void activated ()
	{
		isActivated = true;
	}

}
