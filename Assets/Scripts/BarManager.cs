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
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        secondsToChange = 2;
        StartCoroutine("ChangeDirection");
        gameObject.GetComponent<Transform>().localScale = new Vector3(widithFactor, 1, 1);
  

    }

    void Update()
    {
        float green;
        float blue;
        float difference = Mathf.Abs(gameObject.transform.position.x - stroke.position.x);

        difference = (difference / (widithFactor/2))*2 ;

        if (difference > 1)
        {
            blue = 1;
            green = difference - 1;
        } else {
            green = 0;
            blue = difference;
        }

        spriteRenderer.color = new Color(1f, 1f - green, 1f - blue);

        
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

        
        yield return new WaitForSeconds(secondsToChange);
        secondsToChange = Random.Range(minTime, maxTime);
        speed = -speed;

        rigidbody2D.velocity = new Vector2(speed, 0f);

        StartCoroutine("ChangeDirection");


    }

}
