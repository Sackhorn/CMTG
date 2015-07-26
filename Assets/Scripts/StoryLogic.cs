using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoryLogic : MonoBehaviour
{
    public AudioClip[] TypeSounds;
    public float TypePause = 0.1f;

    private Text _text;
    private AudioSource _audio;
    private string _message;
    private int _typeSoundIndex;

    private void Start()
    {
        _text = gameObject.GetComponent<Text>();
        _audio = gameObject.GetComponent<AudioSource>();

        int index = GameManager.Instance.LastStoryIndex;
        if (index < 0)
            index = 0;
        _message = GameManager.Instance.Stories[index];
        if (index == 1)
            _message += GameManager.Instance._currentDay + 1;
        _text.text = String.Empty;
        _typeSoundIndex = 0;

        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        foreach (char letter in _message.ToCharArray())
        {
            _text.text += letter;
            
            if(letter == '\n')
                yield return new WaitForSeconds(TypePause * 2.0f);
            if (letter == ':')
                yield return new WaitForSeconds(TypePause * 0.6f);

            _audio.PlayOneShot(TypeSounds[_typeSoundIndex++]);
            if (_typeSoundIndex >= TypeSounds.Length)
                _typeSoundIndex = 0;

            yield return new WaitForSeconds(TypePause);
        }

        yield return new WaitForSeconds(2.1f);

        GameManager.Instance.NextLevel();
    }
}
