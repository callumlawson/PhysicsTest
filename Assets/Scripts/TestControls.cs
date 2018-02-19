using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class TestControls : MonoBehaviour
    {
        public NpcSpawner Spawner;
        public InputField NumNPCs;
        public Button RestartButton;

        // Use this for initialization
        [UsedImplicitly]
        private void Start () {
            RestartButton.onClick.AddListener(() =>
            {
                Spawner.SpawnNpcs(Convert.ToInt32(NumNPCs.text));
            });
        }
    }
}
