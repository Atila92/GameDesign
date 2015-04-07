using UnityEngine;
using System.Collections;

public class SpawnRandom : MonoBehaviour
{


	//denne script bruger arrays af positioner(hvor items skal spawn som vi sætter) og array som holder alle items som vi har.
	public Transform[] Powerups_postion;
	public GameObject[] Powerups;
	public int teleport;
	public int prefeb;

	void Start ()
	{
	}
	
	//sætter vores variabler til at være et nyt random tal fra range 0-9 og 0-3 som også er størrelsen på arrays
	void Update ()
	{
		teleport = Random.Range (0, 9);
		prefeb = Random.Range (0, 3);
	}

	void OnGUI ()
	{
		//spawner item et random position fra vores array og et random item fra arrayet
		if (GUI.Button (new Rect (10, 10, 50, 50), "spawn"))
			Instantiate (Powerups [prefeb], Powerups_postion [teleport].position, Powerups_postion [teleport].rotation);
		
		;
		
	}


}
