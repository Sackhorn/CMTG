using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour
{

    public GameObject[] obj;
    public float min;
    public float max;
    public float spawnTime;
    private float time = 0;

    public float off = 0;

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        time += Time.deltaTime;

        if (time >= spawnTime)
        {
            Instantiate(obj[Mathf.RoundToInt(Random.Range(min, max))], gameObject.transform.position + new Vector3(off, 0, 0), Quaternion.identity);
            time = 0;
        }
    }
}
