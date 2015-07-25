using UnityEngine;
using System.Collections;

public class TablicaScript : MonoBehaviour {
	public Transform background;
	public float smoothing=2.0f;
	public GameObject manager;

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

}
