using UnityEngine;
using System.Collections;

public class HealthPoints : MonoBehaviour {

	static public int HP = 50;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(HP);
		if(HP <= 0)
		{
			//Debug.Log("Dead");
		}
	}

	static public void decreaseHP()
	{
		HP -= 10;
	}

}
