using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random =UnityEngine.Random;

public class Papierek_Manager_Script : MonoBehaviour {
	bool areYouDead;
	public float papierekLifeSpan;
	public int papierkiCount=0;
	public int papierkiNumb=5;
	public int lifesLeft=3;
	public static Papierek_Manager_Script Instance;
	public float minApperanceTime=0.3f;
	public float maxApperanceTime=2f;
	public float nextApperance=1f;
	public GameObject GoodPapierek;
	public GameObject BadPapierek;
	public float BadPapierekProbabiity=0.5f;
	int maxPapiereksOnScene;
	int score;

	public static Papierek_Manager_Script instance()
	{
		return Instance;
	}

	void Awake()
	{
		if (Instance)
			Destroy (gameObject);
		else{
			areYouDead =true;
			Instance = this;
		}
		//Sprite.Create (Tlo, new Rect (), new Vector2 (0, 0));
	}


	void StartTimer()
	{
		nextApperance = Random.Range (minApperanceTime, maxApperanceTime);
	}

	bool RandBool(){
		float tmp = Random.Range (0f, 1f);
		if (tmp < BadPapierekProbabiity)
			return true;
		else 
			return false;
	}

	void GenerateNewPapierek()
	{	
		GameObject tempPapierek;
		float width = Random.Range (-Camera.main.orthographicSize*Screen.width/Screen.height, Camera.main.orthographicSize*Screen.width/Screen.height);
		float height = Random.Range (-Camera.main.orthographicSize, Camera.main.orthographicSize); 
		Vector2 papiereksPosition = new Vector2 (width,height);
		bool isPapierekBad = RandBool();
		if (isPapierekBad) 
		{
			Debug.Log ("Nowy Papierek jest generowany");
		tempPapierek=(GameObject)Instantiate (BadPapierek,papiereksPosition, Quaternion.identity);
		} 
		else 
		{
			Debug.Log ("Nowy Papierek jest generowany");
			tempPapierek=(GameObject)Instantiate (GoodPapierek, papiereksPosition, Quaternion.identity);
		}
	}

	IEnumerator PaperCut()
	{
		for (int i=0; i<100; i++) 
			{
				yield return new WaitForSeconds (0.05f);
				GenerateNewPapierek ();
				
			}
	}

	void Update()
	{
		if(lifesLeft>0)
		{
		if (papierkiCount < papierkiNumb) {
			nextApperance -= Time.deltaTime;

			if (nextApperance <= 0) {
				GenerateNewPapierek ();
				StartTimer ();
			}
		} 
			else 
			{
				Debug.Log ("Spierdalaj do innej sceny");
			}

		}
		else
		{	if(areYouDead){
			StartCoroutine(PaperCut());
				papierekLifeSpan=5.0f;
			}
			areYouDead=false;
			Debug.Log("Dedłeś");
		}
			
		}


}
	
