using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeBlackToTransparent : MonoBehaviour {

    public Image panel;
    public float opacity = 1;
    public float speed;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        opacity = Mathf.MoveTowards(opacity, 0f, speed * Time.deltaTime);
        panel.color = new Color(0f,0f,0f,opacity);
	
	}
}
