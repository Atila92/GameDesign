using UnityEngine;
using System.Collections;

public class CapController : MonoBehaviour {


	//variabler
	public GameObject flagRed, flagBlue, flagneutral;

	public bool blueplayer = false;
	public bool redplayer = false;
	
	public float bluecap = 0;
	public float redcap = 0;

	//kaldes når vi starter spillet(obejcet som file er på) her finder vi componenter som vi skal bruge og sætter aktiviteten på nogle obejcter(vores flags)
	void Start () {
		flagRed.SetActive (false);
		flagBlue.SetActive (false);
		flagneutral.SetActive (true);
		flagRed.GetComponent<Renderer>().material.color = Color.red;
		flagneutral.GetComponent<Renderer>().material.color = Color.white;
		flagBlue.GetComponent<Renderer>().material.color = Color.blue;
	
	}
	
	// her tjekker vi hvert frame om blue/red player er i range til at cap flag og inscreser cap via delta.time*20
	void Update () {
		if (blueplayer == true) {
			bluecap += Time.deltaTime * 20;
			redcap -= Time.deltaTime * 20;
		}
		
		if (redplayer == true) {
			redcap += Time.deltaTime * 20;
			bluecap -= Time.deltaTime * 20;
		}
		
		if (redplayer == true && blueplayer == true) {
			bluecap = bluecap;
			redcap = redcap;
		}
		
		if (redcap >= 100) {
			redcap = 100;
			flagRed.SetActive(true);
			flagneutral.SetActive(false);
			flagBlue.SetActive(false);
		}
		if (bluecap >= 100) {
			bluecap = 100;
			flagRed.SetActive(false);
			flagneutral.SetActive(false);
			flagBlue.SetActive(true);
		}
		
		if (bluecap <= 50 && redcap <= 51) {
			
			flagRed.SetActive(false);
			flagneutral.SetActive(true);
			flagBlue.SetActive(false);
		}
		
		if (redcap <= 0) {
			redcap = 0;
		}
		if (bluecap <= 0) {
			bluecap = 0;
		}
	
	}

	//standard GUI i unity, her visert vi cap time og point score efter slaps.
	void OnGUI () {
		// Make a background box
		GUI.Box (new Rect (30, 10, 300, 25),"Red Cap" + " : " + redcap.ToString("0")+ " " + "Blue Cap" + " : " + bluecap.ToString("0"));
		GUI.Box (new Rect (1000, 10, 150, 25),"Red Score " + " : " + GameObject.Find("Hit_red").GetComponent<Collision_point>().red);
		GUI.Box (new Rect (1000, 35, 150, 25),"Blue Score " + " : " + GameObject.Find("Hit_blue").GetComponent<Collision_point>().blue);

		}


}
