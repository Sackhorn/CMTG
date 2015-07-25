using UnityEngine;
using System.Collections;

public class HealthPoints : MonoBehaviour
{
	public int HP = 5;

	private void Start()
	{
	    GameManager.Instance.StartMiniGame(0, 25.0f, 0, 0);
	}

	// Update is called once per frame
	void Update ()
	{
		if(HP <= 0)
		{
			GameManager.Instance.GameOver();
		}
	}
	
	public static void decreaseHP()
	{
		GameObject.Find("ScoreManager").GetComponent<HealthPoints>().HP--;
	}
}
