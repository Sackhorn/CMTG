using UnityEngine;
using System.Collections;

public class HealthPoints : MonoBehaviour
{
	public int HP = 5;
	
	// Update is called once per frame
	void Update ()
	{
		Debug.Log(HP);
		if(HP <= 0)
		{
			//Debug.Log("Dead");
			GameManager.Instance.GameOver();
		}
	}
	
	public static void decreaseHP()
	{
		GameObject.Find("ScoreManager").GetComponent<HealthPoints>().HP--;
	}
}
