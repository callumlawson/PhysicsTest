using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts
{
    public class TestRunner : MonoBehaviour
    {
        public int DefaultStartingNPCs = 1000;
        public int SpawnRadius = 5000;

        [HideInInspector] public int NumNpcs = 1000;

        public static TestRunner Instance;

        // Use this for initialization
        [UsedImplicitly]
        private void Awake()
        {
            //Application.targetFrameRate = 30;
            var autoSync = GetAutoSync();
            Debug.Log("Auto Sync?: " + autoSync);
            Physics.autoSyncTransforms = autoSync;
            NumNpcs = GetNumNpcs();
            Instance = this;
        }

        private int GetNumNpcs()
        {
            var args = Environment.GetCommandLineArgs();
            for (var i = 0; i < args.Length; i++)
            {
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
            return DefaultStartingNPCs;
        }

        private static bool GetAutoSync()
        {
            var args = Environment.GetCommandLineArgs();
            for (var i = 0; i < args.Length; i++)
            {
                if (args[i] == "-autoSync")
                {
                    var input = args[i + 1];
                    var autoSync = Convert.ToBoolean(input);
                    return autoSync;
                }
            }
            return false;
        }
    }
}
