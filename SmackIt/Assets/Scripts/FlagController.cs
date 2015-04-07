using UnityEngine;
using System.Collections;

public class FlagController : MonoBehaviour
{

	// hele denne script bruges til at checke hvilken player der trigger cap point.
	CapController capcontroller;

	void Start ()
	{
	
		capcontroller = GameObject.Find ("Collider").GetComponent<CapController> ();
	}

	void OnTriggerEnter (Collider Col)
	{
		if (Col.tag == "player1") {
			capcontroller.blueplayer = true;
		}
		
		if (Col.tag == "player2") {
			capcontroller.redplayer = true;
		}
		
		
	}
	
	void OnTriggerExit (Collider Col)
	{
		if (Col.tag == "player1") {
			capcontroller.blueplayer = false;
		}
		
		if (Col.tag == "player2") {
			capcontroller.redplayer = false;
		}
		
		
	}
}
