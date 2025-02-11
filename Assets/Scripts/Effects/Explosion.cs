using UnityEngine;

namespace Effects
{
    public class Explosion : MonoBehaviour {
        public float destroyTime = 1.0f; // Note to self: May need adjusting based on animation length

        void Start()
        {
            Destroy(gameObject, destroyTime);
        }
    }
}