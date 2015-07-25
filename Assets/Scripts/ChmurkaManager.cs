using UnityEngine;
using System.Collections;

public class ChmurkaManager : MonoBehaviour
{

    public float speed;
    public int screenWidth;
    public bool repeat;

    private SpriteRenderer _renderer;


    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        _renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void OnBecameInvisible()
    {
        if (Camera.main != null && repeat)
        {
            if (speed > 0)
            {
                float leftSideOfScreen = Camera.main.transform.position.x - Camera.main.orthographicSize * Screen.width / Screen.height;
                gameObject.transform.position = new Vector3(leftSideOfScreen - _renderer.sprite.bounds.size.x, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            else
            {
                float rightSideOfScreen = Camera.main.transform.position.x + Camera.main.orthographicSize * Screen.width / Screen.height;
                gameObject.transform.position = new Vector3(rightSideOfScreen + _renderer.sprite.bounds.size.x, gameObject.transform.position.y, gameObject.transform.position.z);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
