using UnityEngine;
using System.Collections;

public class TablicaScript : MonoBehaviour {
	public Transform background;
	public float smoothing;
	public GameObject manager;
	public Vector2 origin;

	public IEnumerator StartMoving()
	{
		while(Vector2.Distance(transform.position,background.position)>1f)
		      	{
		      transform.position=Vector2.Lerp(transform.position,background.position,smoothing*Time.deltaTime);
		      yield return null;
				}	
		Debug.Log("Tablica wjechała");
		manager.SetActive (true);
	}

	public IEnumerator StartHiding()
	{
	/*	foreach (BadPapierek tmp in GameObject.FindObjectsOfType<BadPapierek> ()) 
		{
			Destroy (tmp.gameObject);
			yield return null;
		}

		foreach (GoodPapierek tmp in GameObject.FindObjectsOfType<GoodPapierek> ()) 
		{
			Destroy (tmp.gameObject);
			yield return null;
		}*/



		while(Vector2.Distance(transform.position,origin)>1f)
		{
			//iTween.MoveTo(gameObject,origin,smoothing*Time.deltaTime);
			transform.position=Vector2.Lerp(transform.position,origin,smoothing*Time.deltaTime);
			yield return null;
		}
		Debug.Log("Tablica spierdala");
	}
	
}
