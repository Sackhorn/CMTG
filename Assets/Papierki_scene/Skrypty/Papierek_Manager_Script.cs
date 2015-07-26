using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random =UnityEngine.Random;

public class Papierek_Manager_Script : MonoBehaviour
{
	public int day;
	public Sprite sprajt;
	private bool areYouDead;
	public float timeTillNextScene;
	public float papierekLifeSpan;
	public int papierkiCount = 0;
	public int papierkiNumb = 5;
	public int lifesLeft = 3;
	public static Papierek_Manager_Script Instance;
	public float minApperanceTime = 0.3f;
	public float maxApperanceTime = 2f;
	public float nextApperance = 1f;
	GameObject GoodPapierek;
	public GameObject GoodPapierek_1;
	public GameObject GoodPapierek_2;
	public GameObject GoodPapierek_3;
	public GameObject BadPapierek;
	public SpriteRenderer tablica;
	public float BadPapierekProbabiity = 0.5f;
	private int maxPapiereksOnScene;
	private int score;

	private bool dead;
	private bool win;


	public static Papierek_Manager_Script instance()
	{
		return Instance;
	}

	private void Awake()
	{
		dead = false;
		win = false;


		papierkiNumb = (int)System.Math.Pow (2, GameManager.Instance._currentDay)+3;
		minApperanceTime = 0.5f - 0.04f * GameManager.Instance._currentDay;
		maxApperanceTime = 1f - 0.04f * GameManager.Instance._currentDay;
		lifesLeft = 3;
		BadPapierekProbabiity = 0.35f;
		papierekLifeSpan = 1f - GameManager.Instance._currentDay * 0.05f;

		if (minApperanceTime <= 0.06f)
			minApperanceTime = 0.1f;
		if (minApperanceTime <= 0.5f)
			minApperanceTime = 0.5f;
		if (papierekLifeSpan <= 0.3f)
			papierekLifeSpan = 0.5f;



		if (Instance)
			Destroy(gameObject);
		else
		{
			areYouDead = true;
			Instance = this;
		}
		//Sprite.Create (Tlo, new Rect (), new Vector2 (0, 0));
	}


	private void StartTimer()
	{
		nextApperance = Random.Range(minApperanceTime, maxApperanceTime);
	}

	private bool RandBool()
	{
		float tmp = Random.Range(0f, 1f);
		if (tmp < BadPapierekProbabiity)
			return true;
		else
			return false;
	}

	void RandPapierek()
	{
		switch((int)Random.Range(1,3))
		{
		case 1:
			GoodPapierek=GoodPapierek_1;
			break;
			
		case 2:
			GoodPapierek=GoodPapierek_2;
			break;
			
		case 3:
			GoodPapierek=GoodPapierek_3;
			break;
		}
	}

	private void GenerateNewPapierek()
	{
		GameObject tmp;
		RandPapierek ();
		float posX = tablica.transform.position.x;
		float posY = tablica.transform.position.y;
		float tabWidth = tablica.bounds.size.x;
		float tabHeight = tablica.bounds.size.y;
		float width = Random.Range (posX - tabWidth / 2 + 20, posX + tabWidth / 2 - 20);
		float height = Random.Range (posY - tabHeight / 2 + 15, posY + tabHeight / 2 - 15);
		Vector2 papiereksPosition = new Vector2 (width, height);
		bool isPapierekBad = RandBool ();
		if (isPapierekBad)
		{

			///Debug.Log ("Nowy Papierek jest generowany");
			tmp = (GameObject)Instantiate (BadPapierek, papiereksPosition, Quaternion.identity);
		}
		else
		{
			//Debug.Log ("Nowy Papierek jest generowany");
			tmp = (GameObject)Instantiate (GoodPapierek, papiereksPosition, Quaternion.identity);
	}
		GameObject obj=GameObject.Find("tablica");
		tmp.transform.parent=obj.transform;


	}
	private IEnumerator PaperCut()
	{
		for (int i = 0; i < 100; i++)
		{
			yield return new WaitForSeconds(0.05f);
			GenerateNewPapierek();

		}
	}

	private void Update()
	{
		if (lifesLeft > 0)
		{
			if (papierkiCount < papierkiNumb)
			{
				nextApperance -= Time.deltaTime;

				if (nextApperance <= 0)
				{
					GenerateNewPapierek();
					StartTimer();
				}
			}
			else if(!win)
			{
				win = true;
				Debug.Log("Spierdalaj do innej sceny");
				StartCoroutine(NextScene());
			}
		}
		else if(!dead)
		{
			dead = true;
			if (areYouDead)
			{
				StartCoroutine(PaperCut());
				papierekLifeSpan = 20.0f;
			}
			areYouDead = false;
			Debug.Log("Dedłeś");
			StartCoroutine(KillScene());
		}

		}

	private IEnumerator KillScene()
	{
		yield return new WaitForSeconds (4);
		GameManager.Instance.GameOver();
	}

	public IEnumerator NextScene()
	{
		StartCoroutine (GameObject.Find ("tablica").GetComponent<TablicaScript> ().StartHiding ());
		Debug.Log("tablica showana");
		//GameObject.Find ("Player").GetComponent<Animator> ().PlayInFixedTime ("sit_000");
		//GameObject.Find ("Player").GetComponent<Animator> ().Play ("walk-1_000");
		GameObject.Find ("Player").GetComponent<Player_Script> ().target = new Vector2 (200.3f, -45.4f);
		yield return StartCoroutine (GameObject.Find("Player").GetComponent<Player_Script>().KickPlyaer());
		//GameObject.Find ("Plyaer").GetComponent<Animator> ().SetTrigger ("IsShiaFromSittin");
		//yield return new WaitForSeconds (3);
		//StartCoroutine (GameObject.Find ("Player").GetComponent<Player_Script> ().KickPlyaer ());
		//StartCoroutine(GameObject.Find ("Player").GetComponent<Player_Script> ().AnimatePlayer());
		//GameObject.Find ("Player").GetComponent<SpriteRenderer> ().sprite = sprajt;

		//yield return new WaitForSeconds (timeTillNextScene);
		yield return  new WaitForSeconds(0.6f);

		GameManager.Instance.ShowStory(3);
		//GameManager.Instance.NextLevel();
	}
}
