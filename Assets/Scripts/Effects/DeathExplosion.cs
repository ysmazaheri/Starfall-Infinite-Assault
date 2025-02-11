using UnityEngine;

public class DeathExplosion : MonoBehaviour {
    public float destroyTime = 1.0f; // Note to self: May need adjusting based on animation length

    void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}