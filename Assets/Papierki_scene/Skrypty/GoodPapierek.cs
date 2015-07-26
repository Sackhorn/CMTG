using UnityEngine;
using System.Collections;

public class GoodPapierek : MonoBehaviour
{
    public GameObject kaczka;
    public GameObject krzyz;
    bool destroy;

    void Awake()
    {
        destroy = true;
        StartCoroutine(StartAutodestruction());
    }

    void OnMouseDown()
    {
        //Destroy(gameObject);
        //StopCoroutine (StartAutodestruction ());
        destroy = false;
        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
        Papierek_Manager_Script pm = Papierek_Manager_Script.instance();
        pm.papierkiCount++;

    }

    IEnumerator StartAutodestruction()
    {
        yield return new WaitForSeconds(Papierek_Manager_Script.instance().papierekLifeSpan);
        if (destroy)
        {
            GameObject tmp;


            tmp = (GameObject)Instantiate(krzyz);
            //tmp.transform.parent=gameObject.transform;
            tmp.transform.position = new Vector2(gameObject.transform.position.x + 55, gameObject.transform.position.y + 30);
            Instantiate(kaczka);
            yield return new WaitForSeconds(0.1f);

            --Papierek_Manager_Script.instance().lifesLeft;
            Destroy(gameObject);
            Destroy(tmp);

        }

    }

}
