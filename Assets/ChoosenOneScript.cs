using UnityEngine;
using System.Collections;

public class ChoosenOneScript : MonoBehaviour {

    public MenuLogic menuManager;

    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("Coll");
        menuManager.addNewChoosenOne(coll.gameObject);
    }
}
