using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{

	    gameObject.GetComponent<Text>().text = GameManager.Instance.Score.ToString();

	}
}
