using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{
//    public enum NavigatingNpcType
//    {
//        Runner,
//        Chaser
//    }

    public class NavigatingNpc : MonoBehaviour
    {
        public int NavigationTargetDistance = 300;
        public int NavigationTargetFrequency = 6;
//        public NavigatingNpcType NpcType = NavigatingNpcType.Runner;

        private NavMeshAgent navAgent;
        private Rigidbody ourRigidbody;

        // Use this for initialization
        [UsedImplicitly] void Start()
        {
            navAgent = GetComponent<NavMeshAgent>();
            navAgent.Warp(transform.position);
            navAgent.autoRepath = true;
            ourRigidbody = GetComponent<Rigidbody>();
            InvokeRepeating("GetNewPath", Random.Range(1.0f, 6.0f), NavigationTargetFrequency);
        }

        private void GetNewPath()
        {
            var offset = Random.insideUnitCircle * NavigationTargetDistance;
            var currentPosition = ourRigidbody.position;
            var newTargetPosition = new Vector3(currentPosition.x + offset.x, 0.0f, currentPosition.z + offset.y);
            navAgent.ResetPath();
            navAgent.SetDestination(newTargetPosition);
        }
    }
}
