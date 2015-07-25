using UnityEngine;
using System.Collections;

public class GameOverLogic : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void backToMenu()
	{
        Fade.FadeThisSit("menu", 0.8f);
	}
}
