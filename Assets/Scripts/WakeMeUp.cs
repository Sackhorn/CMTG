using UnityEngine;
using System.Collections;

public class WakeMeUp : MonoBehaviour
{
    public GameObject Head;


	// Use this for initialization
	void Start ()
	{
		// center head
	    var headSprite = Head.GetComponent<SpriteRenderer>();
	    var headSpriteSize = headSprite.sprite.textureRect;
        Debug.LogWarning(headSpriteSize);
        Debug.LogWarning(Screen.width);
        Head.transform.localScale = new Vector3(Screen.width / headSpriteSize.width, Screen.height / headSpriteSize.height, 1);
	}
	
	// Update is called once per frame
	void Update ()
	{

	}
}
