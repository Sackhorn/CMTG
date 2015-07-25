using UnityEngine;
using System.Collections;

public class CollideCheck : MonoBehaviour
{

    private bool _active = false;
    private bool _leftA = false;
    private bool _rightA = false;
    private bool _upA = false;
    private bool _downA = false;
    private GameObject obj;

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            if (_leftA == true && Input.GetKeyDown(KeyCode.A))
            {
                trafione();
                _leftA = false;
            }
            else if (_rightA == true && Input.GetKeyDown(KeyCode.D))
            {
                trafione();
                _rightA = false;
            }
            else if (_upA == true && Input.GetKeyDown(KeyCode.W))
            {
                trafione();
                _upA = false;
            }
            else if (_downA == true && Input.GetKeyDown(KeyCode.S))
            {
                trafione();
                _downA = false;
            }
            else
            {
                HealthPoints.decreaseHP();
            }
        }
    }

    private void trafione()
    {
        GameManager.Instance.AddScore(10);
        Destroy(obj);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        _active = true;
        if (coll.gameObject.tag == "LeftA")
        {
            _leftA = true;
        }
        else if (coll.gameObject.tag == "RightA")
        {
            _rightA = true;
        }
        else if (coll.gameObject.tag == "UpA")
            _upA = true;
        else if (coll.gameObject.tag == "DownA")
            _downA = true;
        obj = coll.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collf)
    {
        _active = false;
        if (collf.gameObject.tag == "LeftA")
            _leftA = false;
        else if (collf.gameObject.tag == "RightA")
            _rightA = false;
        else if (collf.gameObject.tag == "UpA")
            _upA = false;
        else if (collf.gameObject.tag == "DownA")
            _downA = false;
    }
}
