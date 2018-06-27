using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Editor
{
    [CustomEditor(typeof(TerrainSpawner))]
    public class ObjectBuilderEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            TerrainSpawner script = (TerrainSpawner)target;
            if (GUILayout.Button("Create Terrain"))
            {
                script.SpawnNewTerrain();
            }
        }
    }
}