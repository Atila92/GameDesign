using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
	//Laver simple variabler der skal bruges til at udregne camera positionen + Et Transform array som skal holder players (det er transform fordi vi skal bruge deres positioner). 
	public	Transform[] targets;
	public	float boundingBoxPadding = 2f;
	public	float minimumOrthographicSize = 8f;
	public	float zoomSpeed = 20f;
	Camera camera;


	//Awake kaldes før alt andet den bruges til at sætte camera variablen til at være cameraet i spillet.
	void Awake ()
	{
		camera = GetComponent<Camera> ();
		camera.orthographic = true;
	}
		//denne metode bliver kaldt efter alle update metoder er blevet kaldt. den laver en firkant som som bliver lavet i en anden metode og bruges til at sætte cameraet.
	void LateUpdate ()
	{
		Rect boundingBox = CalculateTargetsBoundingBox ();
		transform.position = CalculateCameraPosition (boundingBox);
		camera.orthographicSize = CalculateOrthographicSize (boundingBox);
	}
		
	//Denne metode udregner en box/firkant som bliver beregnet via targets(players)
	Rect CalculateTargetsBoundingBox ()
	{
		float minX = Mathf.Infinity;
		float maxX = Mathf.NegativeInfinity;
		float minY = Mathf.Infinity;
		float maxY = Mathf.NegativeInfinity;
			
		//vi køre alle players i target igennem og finder deres positioner ved brug at Mathf som er en unity metode til matematiske udregninger.
		foreach (Transform target in targets) {
			Vector3 position = target.position;
				
			minX = Mathf.Min (minX, position.x);
			minY = Mathf.Min (minY, position.y);
			maxX = Mathf.Max (maxX, position.x);
			maxY = Mathf.Max (maxY, position.y);
		}
			
		return Rect.MinMaxRect (minX - boundingBoxPadding, maxY + boundingBoxPadding, maxX + boundingBoxPadding, minY - boundingBoxPadding);
	}
		
	// bruges til at udregne camera postionen du fra boxen hvor alle targets er i.
	Vector3 CalculateCameraPosition (Rect boundingBox)
	{
		Vector2 boundingBoxCenter = boundingBox.center;
			
		return new Vector3 (boundingBoxCenter.x, boundingBoxCenter.y, camera.transform.position.z);
	}
		
	//her beregnes orthographic size som er en indstilling på 2d cameraet i unity som styre højden.
	float CalculateOrthographicSize (Rect boundingBox)
	{
		float orthographicSize = camera.orthographicSize;
		Vector3 topRight = new Vector3 (boundingBox.x + boundingBox.width, boundingBox.y, 0f);
		Vector3 topRightAsViewport = camera.WorldToViewportPoint (topRight);
			
		if (topRightAsViewport.x >= topRightAsViewport.y)
			orthographicSize = Mathf.Abs (boundingBox.width) / camera.aspect / 2f;
		else
			orthographicSize = Mathf.Abs (boundingBox.height) / 2f;
			
		return Mathf.Clamp (Mathf.Lerp (camera.orthographicSize, orthographicSize, Time.deltaTime * zoomSpeed), minimumOrthographicSize, Mathf.Infinity);
	}
}
