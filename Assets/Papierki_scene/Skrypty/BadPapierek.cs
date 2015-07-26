using UnityEngine;
using System.Collections;

public class BadPapierek : MonoBehaviour {
	bool destroy;

	void Awake()
	{
		destroy = true;
		StartCoroutine (StartAutodestruction ());
	}

	void OnMouseDown(){
		//Destroy(gameObject);
		destroy = false;
		//StopCoroutine (StartAutodestruction ());
		Papierek_Manager_Script pm=Papierek_Manager_Script.instance ();
		pm.papierkiCount++;
		pm.lifesLeft=pm.lifesLeft-1;

	}

	IEnumerator StartAutodestruction()
	{
		yield return new WaitForSeconds (Papierek_Manager_Script.instance ().papierekLifeSpan);
		if(destroy)
		Destroy(gameObject);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
