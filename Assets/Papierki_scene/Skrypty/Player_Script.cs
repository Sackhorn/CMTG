using UnityEngine;
using System.Collections;

public class Player_Script : MonoBehaviour
{
	public float waitFor;
    public float smoothing;
    public Vector2 target = new Vector2(75.3f, -45.4f);

    public IEnumerator AnimatePlayer()
    {
        while (Vector2.Distance(transform.position, target) > 2.5f)
        {
            transform.position = Vector2.Lerp(transform.position, target, smoothing * Time.deltaTime);
            yield return null;
        }
        gameObject.GetComponent<Animator>().SetTrigger("IsSittingDown");
		yield return new WaitForSeconds (0.25f);
        StartCoroutine(GameObject.Find("tablica").GetComponent<TablicaScript>().StartMoving());
    }

	public IEnumerator KickPlyaer()
	{
		gameObject.GetComponent<Animator> ().SetTrigger ("IsShiaRightFromSittin");

		while (Vector2.Distance(transform.position, target) > 2.5f)
		{
			//yield return new WaitForSeconds (2f);
			gameObject.GetComponent<Animator> ().SetTrigger ("IsWalking");
			transform.position = Vector2.Lerp(transform.position, target, smoothing * Time.deltaTime);
			yield return null;
		}

	}

}
