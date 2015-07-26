using UnityEngine;
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

	private void Start()
	{
        _source = gameObject.GetComponent<AudioSource>();
        //Timming.Start(_source.clip.length, onFinish);
	    StartCoroutine("game");
	}

    IEnumerator game()
    {
        while (Klawisze.transform.localPosition.x > -350)
        {
            Klawisze.transform.localPosition -= new Vector3(80 * Time.deltaTime, 0, 0);

            if (Klawisze.transform.localPosition.x < -50 && !_source.isPlaying)
            {
                _source.Play();
            }

            yield return new WaitForSeconds(0.005f);
        }


        yield return new WaitForSeconds(_source.clip.length);

       // Debug.LogWarning("ssssssssssssssssss");

        GameManager.Instance.NextLevel();
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
        if (_source.isPlaying && _source.clip.length - _source.time - SoundEndOffset > distance / ArrowSpeed)
	    {
	        time += Time.deltaTime;
	        if (time >= spawnTime)
	        {
                var arrow = Instantiate(obj[Mathf.RoundToInt(Random.Range(min, max))], new Vector3(distance, 9, 0), Quaternion.identity) as GameObject;
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
