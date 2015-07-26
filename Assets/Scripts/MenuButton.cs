using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		/*var bounds = gameObject.GetComponent<SpriteRenderer>().bounds;
	    var cam = Camera.main;
		bounds.center = cam.WorldToScreenPoint(bounds.center);
	    var ex = bounds.extents;
	    ex.x *= cam.orthographicSize;
	    ex.y *= cam.orthographicSize;
	    bounds.extents = ex;

		if (bounds.Contains(Input.mousePosition))
		{

			Debug.LogWarning("sssssssssssssssssssssss");
		}
		Debug.LogWarning(bounds);
		//Debug.LogWarning(Input.mousePosition);*/
	}

	void OnMouseEnter()
	{
		gameObject.SetActive(false);
	}
}
