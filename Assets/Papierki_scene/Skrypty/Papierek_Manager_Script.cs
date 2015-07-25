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
	public SpriteRenderer tablica;
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
		float posX =tablica.transform.position.x;
		float posY =tablica.transform.position.y;
		float tabWidth = tablica.bounds.size.x;
		float tabHeight = tablica.bounds.size.y;
		float width = Random.Range (posX-tabWidth/2+17,posX+tabWidth/2-17);
		float height = Random.Range (posY-tabHeight/2+12,posY+tabHeight/2-12); 
		Vector2 papiereksPosition = new Vector2 (width,height);
		bool isPapierekBad = RandBool();
		if (isPapierekBad) 
		{
			Debug.Log ("Nowy Papierek jest generowany");
			Instantiate (BadPapierek,papiereksPosition, Quaternion.identity);
		} 
		else 
		{
			Debug.Log ("Nowy Papierek jest generowany");
			Instantiate (GoodPapierek, papiereksPosition, Quaternion.identity);
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
				papierekLifeSpan=20.0f;
			}
			areYouDead=false;
			Debug.Log("Dedłeś");
		}
			
		}


}
	
