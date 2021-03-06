﻿using UnityEngine;
using System.Collections;

public class HealthPoints : MonoBehaviour
{
	public int HP = 5;

    private AudioSource _source;
    private float time;

    public GameObject[] obj;
    public float min = 0;
    public float max = 3;
    public float spawnTime = 0.455f;
    public float off = -3;
    public float ArrowSpeed = 60;
    public float SoundEndOffset = 1.2f;

    public GameObject Klawisze;

    public AudioClip Sound1;
    public AudioClip Sound2;

    private float playTime;

	private void Start()
	{
        _source = gameObject.GetComponent<AudioSource>();
        //Timming.Start(_source.clip.length, onFinish);
	    StartCoroutine("game");
	}

    IEnumerator game()
    {
        playTime = Sound1.length;
        _source.clip = GameManager.Instance._currentDay > 0 ? Sound2 : Sound1;

        float t1, t2 = 0;
        t1 = Time.time;

        while (Klawisze.transform.localPosition.x > -350)
        {
            Klawisze.transform.localPosition -= new Vector3(300 * Time.deltaTime, 0, 0);

            if (Klawisze.transform.localPosition.x < -50 && !_source.isPlaying)
            {
                t2 = Time.time;
                //_source.PlayOneShot(GameManager.Instance._currentDay > 0 ? Sound2 : Sound1);
                _source.Play();
            }

            yield return new WaitForSeconds(0.005f);
        }

        //Debug.LogWarning("ait: "+ (t2 - t1).ToString());

        yield return new WaitForSeconds(playTime - (t2 - t1));

       // Debug.LogWarning("ssssssssssssssssss");

        //GameManager.Instance.NextLevel();
        GameManager.Instance.ShowStory(4);
    }

	// Update is called once per frame
	void Update ()
	{
        /*if(Timming.IsFading)
            return;*/

		if(HP <= 0)
		{
			GameManager.Instance.GameOver();
		}

	    float distance = 118.6f + off;
        if (_source.isPlaying && playTime - _source.time - SoundEndOffset > distance / ArrowSpeed)
	    {
	        time += Time.deltaTime;
	        if (time >= spawnTime)
	        {
                var arrow = Instantiate(
                    obj[Mathf.RoundToInt(Random.Range(min, max))],
                     new Vector3(distance, 9, 0),
                    Quaternion.identity) as GameObject;
                arrow.GetComponent<ArrowMovement>().ArrowSpeed = ArrowSpeed;
	            time = 0;
	        }
	    }
	}
	
	public static void decreaseHP()
	{
		GameObject.Find("ScoreManager").GetComponent<HealthPoints>().HP--;
	}


}
