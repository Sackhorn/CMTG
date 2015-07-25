using UnityEngine;
using System.Collections;

public class ChmurkaManager : MonoBehaviour
{

    public float speed;
    public int screenWidth;

    private SpriteRenderer renderer;


    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void OnBecameInvisible()
    {
        float leftSideOfScreen = Camera.main.transform.position.x - Camera.main.orthographicSize * Screen.width / Screen.height;
        gameObject.transform.position = new Vector3(leftSideOfScreen - renderer.sprite.bounds.size.x , gameObject.transform.position.y, gameObject.transform.position.z);
    }
}
