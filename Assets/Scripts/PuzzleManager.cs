using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class PuzzleManager : MonoBehaviour 
{
	
	bool startCheck = false;
	bool puzzleComplete = false;
	bool temp = true;
	public VRTK_InteractableObject InteractableObjectScript;
	public GameObject CompletionAnimation;
	
	
	

	void Start () 
	{
		InteractableObjectScript.SubscribeToInteractionEvent(VRTK_InteractableObject.InteractionType.Grab, setupPuzzle);  //Subscribing the Setup Puzzle method to the "Grab" event for the object.
	}


	void Update () 
	{
		if (startCheck)
		{
			checkpuzzle(); //See if the pieces all activated.
			if (puzzleComplete)
			{
				if (temp == true) //Just write it once, please.
				{
					temp = false;
					CompletionAnimation.SetActive(true); //Particle Effect to let you know you completed it.
				}
			}
		}

		
	}


	//Set the points of the puzzle to active so they are visable
	void setupPuzzle (object sender, InteractableObjectEventArgs e)
	{
		foreach (var point in PuzzlePoints)
		{
			point.gameObject.SetActive(true);
		}
		startCheck = true;
	}
	
	//Check each point in the puzzle to see if they have been activated.
	//If all points have been activated then set puzzleComplete to true;
	void checkpuzzle ()
	{
		int numActivated = 0;
		foreach (var point in PuzzlePoints)
		{
			if (point.GetComponent<PuzzlePiece>().isActivated)
			{
				numActivated++;
			}
		}

		if (numActivated == PuzzlePoints.Length)
		{
			puzzleComplete = true;
		}
	}


	[Header("PuzzlePieces")]
	[Tooltip("The game objects that represent the points to be ignited")]
	public GameObject[] PuzzlePoints;
	public Collider PuzzleTrigger;

	[Header("Dubugging")]
	[Tooltip("This bool has been made public for debugging purposes.")]
	public bool PuzzleActivated = false;
}
