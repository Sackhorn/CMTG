using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IntroScript : MonoBehaviour
{

    private float timer;

    private int state;

	// Use this for initialization
	void Start ()
	{
	    timer = 0;
	    state = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    timer += Time.deltaTime;

	    switch (state)
	    {
            case 0:
	        {
	            float pos = timer / 1.0f;
	            gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1 - pos);

	            if (pos >= 1.0f)
	            {
	                state++;
	                timer = 0;
	                gameObject.GetComponent<Image>().enabled = false;
	            }
	        }
	            break;

            case 1:
	        {
                float pos = timer / 2.0f;

                if (pos >= 1.0f)
                {
                    state++;
                    timer = 0;
                    gameObject.GetComponent<Image>().enabled = true;
                }
	        }
	            break;

            case 2:
	        {
	            float pos = timer / 0.4f;
                gameObject.GetComponent<Image>().color = new Color(0, 0, 0, pos);

	            if (pos >= 1.0f)
	            {
	                Application.LoadLevel("menu");
	            }
	        }
	            break;
	    }
	}
}
