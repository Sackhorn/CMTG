using UnityEngine;

public class DestroyerScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        Destroy(coll.gameObject);
        HealthPoints.decreaseHP();
    }
}
