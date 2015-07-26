using UnityEngine;
using System.Collections;

public class GoodPapierek : MonoBehaviour {

	bool destroy;

	void Awake()
	{
		destroy = true;
		StartCoroutine (StartAutodestruction ());
	}

	void OnMouseDown()
	{
		//Destroy(gameObject);
		//StopCoroutine (StartAutodestruction ());
		destroy = false;
		gameObject.GetComponent<SpriteRenderer> ().color = Color.gray;
		Papierek_Manager_Script pm=Papierek_Manager_Script.instance ();
		pm.papierkiCount++;

	}

	IEnumerator StartAutodestruction()
	{
		yield return new WaitForSeconds (Papierek_Manager_Script.instance ().papierekLifeSpan);
			if (destroy) 
				{
					--Papierek_Manager_Script.instance ().lifesLeft;
					Destroy (gameObject);
				}

	}

}
