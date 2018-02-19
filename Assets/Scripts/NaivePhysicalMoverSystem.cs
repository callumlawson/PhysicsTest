using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts
{
    public class NaivePhysicalMoverSystem : MonoBehaviour
    {
        private List<Rigidbody> npcRigidbodyList;

        // Use this for initialization
        [UsedImplicitly]
        private void Start ()
        {
            npcRigidbodyList = NpcSpawner.NpcRigidbodyList;
            Application.targetFrameRate = 30;
            Physics.autoSyncTransforms = false;
        }
	
        // Update is called once per frame
        [UsedImplicitly]
        private void FixedUpdate()
        {
            if (!NpcSpawner.IsSimulating) return;
            for (var i = 0; i < npcRigidbodyList.Count; i++)
            {
                var npcRigidbody = npcRigidbodyList[i];
                npcRigidbody.MovePosition(npcRigidbody.position + transform.forward * Time.deltaTime);
            }
        }
    }
}
