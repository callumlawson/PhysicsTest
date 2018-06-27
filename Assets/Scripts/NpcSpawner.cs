using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts
{
    public class NpcSpawner : MonoBehaviour
    {
        [UsedImplicitly] public GameObject Npc;

        public static bool IsSimulating;
        public static readonly List<GameObject> NpcList = new List<GameObject>(5000);
        public static readonly List<Rigidbody> NpcRigidbodyList = new List<Rigidbody>(5000);

        private const int MaxFrameLengthForSpawningMillis = 500;
        private Stopwatch stopwatch;
        private TimeSpan lastTime;

        // Use this for initialization
        [UsedImplicitly] private void Start ()
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
            SpawnNpcs(TestRunner.Instance.NumNpcs);
            NavMesh.pathfindingIterationsPerFrame = 99999;
        }

        public void SpawnNpcs(int numNPCs)
        {
            StartCoroutine(SpawnCoroutine(numNPCs));
        }

        private IEnumerator SpawnCoroutine(int numNPCs)
        {
            IsSimulating = false;
            ClearExistingNpcs();
            for (var i = 0; i < numNPCs; i++)
            {
                var newNpc = Instantiate(Npc, Util.RandomPosition(TestRunner.Instance.SpawnRadius), Quaternion.identity);
                NpcList.Add(newNpc);
                NpcRigidbodyList.Add(newNpc.GetComponent<Rigidbody>());
                if ((i+1) % 500 == 0)
                {
                    Debug.Log(string.Format("Spawned {0} Npcs", i+1));
                }
                if ((stopwatch.Elapsed - lastTime).TotalMilliseconds > MaxFrameLengthForSpawningMillis)
                {
                    lastTime = stopwatch.Elapsed;
                    yield return null;
                }
            }
            IsSimulating = true;
        }

        private static void ClearExistingNpcs()
        {
            NpcRigidbodyList.Clear();
            foreach (var npc in NpcList)
            {
                Destroy(npc);
            }
            NpcList.Clear();
        }
    }
}
