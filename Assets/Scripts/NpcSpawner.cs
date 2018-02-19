using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public class NpcSpawner : MonoBehaviour
    {
        [UsedImplicitly] public GameObject Npc;

        public int StartingNPCs = 1000;
        public int SpawnRadius = 5000;

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
            SpawnNpcs(GetNumNpcs());

        }

        public void SpawnNpcs(int numNPCs)
        {
            StartCoroutine(SpawnCoroutine(numNPCs));
        }

        private int GetNumNpcs()
        {
            var args = Environment.GetCommandLineArgs();
            for (var i = 0; i < args.Length; i++)
            {
                Debug.Log("Command line argument: " + i + ": " + args[i]);
                if (args[i] == "-numNpcs")
                {
                    var input = args[i + 1];
                    var numNpcs = Convert.ToInt32(input);
                    if (numNpcs > 0)
                    {
                        return numNpcs;
                    }
                }
            }
            return StartingNPCs;
        }

        private IEnumerator SpawnCoroutine(int numNPCs)
        {
            IsSimulating = false;
            ClearExistingNpcs();
            for (var i = 0; i < numNPCs; i++)
            {
                var newNpc = Instantiate(Npc, RandomPosition(), Quaternion.identity);
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

        private Vector3 RandomPosition()
        {
            var insideCircle = Random.insideUnitCircle * SpawnRadius;
            return new Vector3(insideCircle.x, 1, insideCircle.y);
        }
    }
}
