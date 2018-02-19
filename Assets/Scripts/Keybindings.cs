using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts
{
    public class Keybindings : MonoBehaviour
    {
        public GameObject Canvas;
        public GameObject Camera;

        [UsedImplicitly] private void Update () {
            if (Input.GetKeyDown(KeyCode.P))
            {
                //TODO: Put canvas on separate camera?
                Canvas.SetActive(!Canvas.activeSelf);
                Camera.SetActive(!Camera.activeSelf);
            }
        }
    }
}
