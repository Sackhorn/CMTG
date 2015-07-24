using UnityEngine;
using System.Collections;

public class BarManager : MonoBehaviour
{

    public Transform stroke;
    public int secondsToChange;
    public int minTime;
    public int maxTime;
    public float speed;
    public float widithFactor;

    private Rigidbody2D rigidbody2D;

    // Use this for initialization
    void Start()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine("ChangeDirection");
        gameObject.GetComponent<Transform>().localScale = new Vector3(widithFactor, 1, 1);
        rigidbody2D.velocity = new Vector2(speed, 0f);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "leftBorder" || collision.gameObject.tag == "rightBorder")
        {
            speed = -speed;
            rigidbody2D.velocity = new Vector2(speed, 0f);
        }
    }

    // Update is called once per frame

    public void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Przegrałeś");
    }

    IEnumerator ChangeDirection()
    {

        secondsToChange = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(secondsToChange);

        speed = -speed;

        rigidbody2D.velocity = new Vector2(speed, 0f);

        StartCoroutine("ChangeDirection");


    }

}
