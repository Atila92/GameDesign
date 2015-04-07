using UnityEngine;
using System.Collections;

public class Collision_point : MonoBehaviour
{
	//variabler
	public	float Red_point = 0;
	public float Blue_point = 0;
	public string blue;
	public string red;
	public bool Shaking;
	private float ShakeDecay;
	private float ShakeIntensity;
	private Vector3 OriginalPos;
	private Quaternion OriginalRot;
	public Vector3 StartRed;
	public Vector3 StartBlue;

	//denne metoder bliver kun kaldt når et obejct med collider rammes af et andet obejct med en collider
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.name == "rightHand_blue" || other.gameObject.name == "leftHand_blue") {
			Red_point ++;
			GameObject.Find ("Main Camera").SendMessage ("DoShake");
			//sætter bare boolea for red eller blue

		}
		if (other.gameObject.name == "rightHand_red" || other.gameObject.name == "leftHand_red") {
			Blue_point++;

			GameObject.Find ("Main Camera").SendMessage ("DoShake");
		
		}
	}
	//sætter shaking til false så vi starter spillet
	void Start ()
	{
		Shaking = false;   
	}	

	//checker hele tiden som ShakeIntensity er under 0 eller shaker den camera.
	void Update ()
	{
		blue = Blue_point.ToString ("");
		red = Red_point.ToString ("");
		if (ShakeIntensity > 0) {
			transform.position = OriginalPos + Random.insideUnitSphere * ShakeIntensity;
			transform.rotation = new Quaternion (OriginalRot.x + Random.Range (-ShakeIntensity, ShakeIntensity) * .2f,
			                                    OriginalRot.y + Random.Range (-ShakeIntensity, ShakeIntensity) * .2f,
			                                    OriginalRot.z + Random.Range (-ShakeIntensity, ShakeIntensity) * .2f,
			                                    OriginalRot.w + Random.Range (-ShakeIntensity, ShakeIntensity) * .2f);
			
			ShakeIntensity -= ShakeDecay;
		} else if (Shaking) {
			Shaking = false;
			transform.position = new Vector3 (0f, 0f, 0f);
		}
		
	}
	     
	//metode som bliver kaldt når der er collision, er sættes værdier på ShakeIntensity som bliver checked i update.
	public void DoShake ()
	{
		OriginalPos = transform.position;
		OriginalRot = transform.rotation;
		
		ShakeIntensity = 0.1f;
		ShakeDecay = 0.01f;
		Shaking = true;
	}


}
