using UnityEngine;
using System.Collections;

public class GoodPapierek : MonoBehaviour {
	public GameObject kaczka;
	public GameObject krzyz;
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
					/*GameObject tmp;


			tmp =(GameObject)Instantiate(krzyz,gameObject.transform.position,Quaternion.identity);
			tmp.transform.parent=gameObject.transform;
			tmp.transform.position=new Vector2(0,0);*/
			//yield return new WaitForSeconds(0.1f);
					Instantiate(kaczka);
					--Papierek_Manager_Script.instance ().lifesLeft;
					Destroy (gameObject);
					
				}

	}

}
