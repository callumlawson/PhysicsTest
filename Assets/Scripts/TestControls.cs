using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class TestControls : MonoBehaviour
    {
        public NpcSpawner NpcSpawner;
        public InputField NumNPCs;
        public Button RestartButton;

        // Use this for initialization
        [UsedImplicitly]
        private void Start () {
            RestartButton.onClick.AddListener(() =>
            {
                NpcSpawner.SpawnNpcs(Convert.ToInt32(NumNPCs.text));
            });
        }
    }
}
