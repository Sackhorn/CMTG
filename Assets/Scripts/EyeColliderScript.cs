using UnityEngine;
using System.Collections;

public class EyeColliderScript : MonoBehaviour {
    private bool isEyeUp;

	// Use this for initialization
	void Start () {
        isEyeUp = false;
	
	}
	
	void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Wściekłe kutangi");
        if(other.tag.Equals("EyeColliderTag"))
        {
            isEyeUp = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("isOut");
        if (other.tag.Equals("EyeColliderTag"))
        {
            isEyeUp = false;
        }
    }

    public bool getIsEyeUp() { return isEyeUp; }
}
