using UnityEngine;
using System.Collections;

public class movment : MonoBehaviour
{
	//variabler
	public float speed ;
	public float rotationSpeed;
	Transform myTrans;
	Vector3 myPos;
	Vector3 myRot;
	float angle;

	// giver vores variabler positioner og tranform og rotation som skal bruges for movment
	void Start ()
	{
		myTrans = transform;
		myPos = myTrans.position;
		myRot = myTrans.rotation.eulerAngles;
	}
	
	// vi bruger fixupdate fordi den er bedre en update da den bliver kaldt mere ofte og er perfect til bruge når det kommer til controlles.
	void FixedUpdate ()
	{
		
		//her konvater vi angle som er i degress til radianer.   
		angle = myTrans.eulerAngles.magnitude * Mathf.Deg2Rad;
		
		
		// højre og venstre controlles
		if (Input.GetKey (KeyCode.RightArrow)) {
			myRot.z -= rotationSpeed;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			myRot.z += rotationSpeed;
		}
		
		
		//frem og tilbage
		if (Input.GetKey (KeyCode.UpArrow)) {
			
			myPos.x += (Mathf.Cos (angle) * speed) * Time.deltaTime;
			myPos.y += (Mathf.Sin (angle) * speed) * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			myPos.x -= (Mathf.Cos (angle) * speed) * Time.deltaTime;
			myPos.y -= (Mathf.Sin (angle) * speed) * Time.deltaTime;    
		}
		
		
		//giver player vores rotation og position
		myTrans.position = myPos;
		myTrans.rotation = Quaternion.Euler (myRot);
		
	}
}
