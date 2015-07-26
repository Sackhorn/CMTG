using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public float FadeInTime = 1.5f;
    public float FadeOutTime = 1.5f;

    private float _fadeInAcc;
    private float _fadeOutAcc;
    private string _nextLevelName;

    private bool _fadeIn;
    private bool _fadeOut;

    private Image _image;

    // Use this for initialization
    private void Start()
    {
        _fadeInAcc = 0.0f;
        _fadeOutAcc = 0.0f;
        _nextLevelName = null;
        _fadeIn = true;
        _fadeOut = false;
        _image = gameObject.GetComponent<Image>();
    }

    private void Update()
    {
        if (_image == null)
            return;

        if (_fadeIn)
        {
            _fadeInAcc += Time.deltaTime;
            _image.color = new Color(0, 0, 0, 1 - _fadeInAcc / FadeInTime);

            if (_fadeInAcc >= FadeInTime)
            {
                _fadeIn = false;
                gameObject.SetActive(false);
            }
        }
        else if (_fadeOut)
        {
            _fadeOutAcc += Time.deltaTime;
            _image.color = new Color(0, 0, 0, _fadeOutAcc / FadeOutTime);

            if (_fadeOutAcc >= FadeOutTime)
            {
                _fadeOut = false;
                Application.LoadLevel(_nextLevelName);
            }
        }
    }

    private void startFadeOut(string sceneName)
    {
        _fadeOut = true;
        _nextLevelName = sceneName;
        gameObject.SetActive(true);
    }

    public static void FadeThisSit(string nextScene)
    {
        // Hide UI
        var ui = GameObject.Find("UI");
        if (ui != null)
        {
            var fade = ui.transform.Find("Fade");
            if (fade != null)
            {
                fade.GetComponent<Fade>().startFadeOut(nextScene);
                return;
            }
        }

        // No fade just go! Go!
        Debug.Log("Fade without a fade.");
        Application.LoadLevel(nextScene);

        // Error
        //Debug.LogError("Cannot fade into another scene. Missing fade canvas.");
    }
}
