using UnityEngine;
using System.Collections;

public class StrokeManager : MonoBehaviour
{

    public float strokeSpeed;
    public bool touchLeftBorder;
    public bool touchRightBorder;

    private Rigidbody2D rigidbody;

    // Use this for initialization
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        DayConfigurator(GameManager.Instance._currentDay);

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "leftBorder")
        {
            touchLeftBorder = true;
        }
        else if (collision.gameObject.tag == "rightBorder")
        {
            touchRightBorder = true;
        }
    }

    private void DayConfigurator(int dayNumber)
    {
        for (int i = 0; i < dayNumber; i++)
        {
            strokeSpeed = strokeSpeed * 1.1f;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        touchLeftBorder = false;
        touchRightBorder = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !touchLeftBorder)
        {
            rigidbody.velocity = new Vector2(-strokeSpeed, 0);
        }
        else if (Input.GetMouseButton(1) && !touchRightBorder)
        {
            rigidbody.velocity = new Vector2(strokeSpeed, 0);
        }
        else
        {
            rigidbody.velocity = Vector2.zero;
        }
    }
}
