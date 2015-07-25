using UnityEngine;
using System.Collections;

public class Player_Script : MonoBehaviour
{
    public float smoothing = 100.0f;
    public Vector3 target = new Vector3(75.3f, -45.4f, 0);

    public IEnumerator AnimatePlayer()
    {
        while (Vector2.Distance(transform.position, target) > 5f)
        {
            transform.position = Vector3.Slerp(transform.position, target, smoothing * Time.deltaTime);
            yield return null;
        }
        gameObject.GetComponent<Animator>().SetTrigger("IsSittingDown");
        StartCoroutine(GameObject.Find("tablica").GetComponent<TablicaScript>().StartMoving());
    }

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }
}
