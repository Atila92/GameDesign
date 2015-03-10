using UnityEngine;
using System.Collections;

public class PlayerMobility : MonoBehaviour {

	public float speed = 5f;
	public float rotSpeed = 180f;

	// Update is called once per frame
	void Update () {

		Quaternion rot = transform.rotation;

		float z = rot.eulerAngles.z;

		z -= Input.GetAxis ("Horizontal") * rotSpeed * Time.deltaTime;

		rot = Quaternion.Euler(0,0,z);

		transform.rotation = rot; 

		Vector3 pos = transform.position;

		Vector3 velocity = new Vector3 (0, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0);

		pos += rot * velocity;

		transform.position = pos;


		//var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
//		Quaternion rot = Quaternion.LookRotation (transform.position, Vector3.forward);
//
//		transform.rotation = rot;
//		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
//		rigidbody2D.angularVelocity = 0;
//
//		float input = Input.GetAxis ("Vertical");
//		//float input2 = Input.GetAxis ("Horizontal");
//		rigidbody2D.AddForce (gameObject.transform.up * speed * input);
//		//rigidbody2D.AddForce (gameObject.transform.right * speed * input2);
//
//		if (Input.GetKey("a")) {
//			RotateLeft();
//		}
//		else if (Input.GetKey("d")) {
//			RotateRight();
//		}
//
//		}
//	float degreesPerSecond = 45;
//	void RotateLeft(){
//		transform.Translate (Vector3.left * Time.deltaTime);
//		transform.Rotate (Vector3.forward, degreesPerSecond * Time.deltaTime);
//	}
//	void RotateRight(){
//		transform.Translate (Vector3.right * Time.deltaTime);
//		transform.Rotate (Vector3.forward, -degreesPerSecond * Time.deltaTime);
		}
}
