using UnityEngine;
using System.Collections;

public class CharScript : MonoBehaviour
{

	// Use this for initialization
	void Start () {
	

        Destroy(gameObject, 40);
	}
	
	// Update is called once per frame
    private void Update()
    {
        gameObject.transform.position += new Vector3(Time.deltaTime * 30, 0, 0);
    }

}
