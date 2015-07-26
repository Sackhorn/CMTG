using UnityEngine;
using System.Collections;

public class BarManager : MonoBehaviour
{

    public Transform stroke;
    public PlayerManager_Bridge playerManager;
    public float secondsToChange;
    public float secondsToStart;
    public int minTime;
    public int maxTime;
    public float speed;
    public float widithFactor;
    

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start()
    {
        DayConfigurator(GameManager.Instance._currentDay);
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        secondsToChange = secondsToStart;
        StartCoroutine("ChangeDirection");
        gameObject.GetComponent<Transform>().localScale = new Vector3(widithFactor, 1, 1);
  

    }

    void Update()
    {
        float green;
        float blue;
        float difference = Mathf.Abs(gameObject.transform.position.x - stroke.position.x);

        if (!playerManager.Faiiling)
        {
            GameManager.Instance.AddScore(1);
        }

        difference = (difference / (widithFactor / 2)) / 16;

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

    private void DayConfigurator(int dayNumber)
    {
        for (int i = 0; i < dayNumber; i++)
        {
            speed = speed * 1.1f;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "leftBorder" || collision.gameObject.tag == "rightBorder")
        {
            speed = -speed;
            _rigidbody2D.velocity = new Vector2(speed, 0f);
        }
        else if (collision.gameObject.tag == "stroke")
        {
            playerManager.StopFalling();
        }
    }

    // Update is called once per frame

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "stroke")
            playerManager.StartFalling();
    }

    IEnumerator ChangeDirection()
    {

        
        yield return new WaitForSeconds(secondsToChange);
        secondsToChange = Random.Range(minTime, maxTime);
        speed = -speed;

        _rigidbody2D.velocity = new Vector2(speed, 0f);

        StartCoroutine("ChangeDirection");


    }

}
