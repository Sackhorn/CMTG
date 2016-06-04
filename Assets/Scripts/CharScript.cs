using UnityEngine;
using System.Collections;

public class CharScript : MonoBehaviour
{
    private bool _fading = false;
    Renderer renderer;
    Color colorStart;
    Color colorEnd;
    public float fadeDuration;
    public float animDuartion;
    float t = 0.0f;
    bool _choosenOne = false;
    bool _anim = false;
    // Use this for initialization
    void Start () {
        renderer = gameObject.GetComponent<Renderer>();
        colorStart = renderer.material.color;
        colorEnd = new Color(colorStart.r, colorStart.g, colorStart.b, 0.0f);

        Destroy(gameObject, 40);
	}
	
	// Update is called once per frame
    private void Update()
    {
        if (_fading)
        {
            t += Time.deltaTime;
            renderer.material.color = Color.Lerp(colorStart, colorEnd, t / fadeDuration);
        }
        if(!_anim)
            gameObject.transform.position += new Vector3(Time.deltaTime * 30, 0, 0);
        else
        {
            if (animDuartion > 0)
            {
                gameObject.transform.position += new Vector3(0, Time.deltaTime * 45, 0);
                gameObject.transform.localScale += new Vector3(-Time.deltaTime * 1.2f, Time.deltaTime * 1.2f, 0);
                animDuartion -= Time.deltaTime;
            }
            else
            {
                gameObject.GetComponent<Animator>().SetTrigger("doit");
            }
        }
    }

    public void Fade()
    {
        _fading = true;
    }

    public void Anim()
    {
        _anim = true;
    }

}
