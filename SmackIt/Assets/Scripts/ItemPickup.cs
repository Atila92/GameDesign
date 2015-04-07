using UnityEngine;
using System.Collections;

public class ItemPickup : MonoBehaviour
{

	bool redspeed = false;
	bool bluespeed = false;


	//standard Trigger som checker hvem der trigger item.
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.name == "RedPlayer") {
			Debug.Log ("true");
			redspeed = true;
		}
		if (other.gameObject.name == "BluePlayer") {
			Debug.Log ("true");
			bluespeed = true;

		


		}
	}
	//timer som køre noget og venter 5 sec. og køre noget andet efter
	IEnumerator RedSpeedTimer ()
	{
		GameObject.Find ("RedPlayer").GetComponent<movment2> ().speed = 7f;
		yield return new WaitForSeconds (5);
		GameObject.Find ("RedPlayer").GetComponent<movment2> ().speed = 5f;
		redspeed = false;
		Destroy (GameObject.Find ("Speed(Clone)"));
	
	}
	//timer som køre noget og venter 5 sec. og køre noget andet efter
	IEnumerator BlueSpeedTimer ()
	{
		GameObject.Find ("BluePlayer").GetComponent<movment> ().speed = 7f;
		yield return new WaitForSeconds (5);
		GameObject.Find ("BluePlayer").GetComponent<movment> ().speed = 5f;
		Destroy (GameObject.Find ("Speed(Clone)"));
	
		bluespeed = false;
	}
	//timer som bruges til at slette item når den er taget efter noget tid
	IEnumerator Destroyitem ()
	{
		yield return new WaitForSeconds (0.5f);
		Destroy (GameObject.Find ("Speed(Clone)"));
	}

	//update som checker som item er taget og af hvem.
	void Update ()
	{
		if (redspeed == true) {
			StartCoroutine (RedSpeedTimer ());

		}

		if (bluespeed == true) {
			StartCoroutine (Destroyitem ());
			StartCoroutine (BlueSpeedTimer ());

		}
	
	}

}
