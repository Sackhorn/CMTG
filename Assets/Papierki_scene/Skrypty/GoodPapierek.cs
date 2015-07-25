using UnityEngine;
using System.Collections;

public class GoodPapierek : MonoBehaviour {

	void Awake()
	{
		StartCoroutine (StartAutodestruction ());
	}
	void OnMouseDown(){
		Destroy(gameObject);
		Papierek_Manager_Script pm=Papierek_Manager_Script.instance ();
		pm.papierkiCount++;

	}

	IEnumerator StartAutodestruction()
	{
		yield return new WaitForSeconds (Papierek_Manager_Script.instance ().papierekLifeSpan);
		--Papierek_Manager_Script.instance ().lifesLeft;
		Destroy(gameObject);

	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
