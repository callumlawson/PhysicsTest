using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts
{
    public class NaivePhysicalMover : MonoBehaviour
    {
        private Rigidbody ourRigidbody;

        // Use this for initialization
        [UsedImplicitly]
        private void Start ()
        {
            ourRigidbody = GetComponent<Rigidbody>();
        }
	
        // Update is called once per frame
        [UsedImplicitly]
        private void FixedUpdate()
        {
            if (NpcSpawner.IsSimulating)
            {
                ourRigidbody.MovePosition(transform.position + transform.forward * Time.deltaTime);
            }
        }
    }
}
