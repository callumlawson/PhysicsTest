using UnityEngine;

namespace Assets.Scripts
{
    public class TerrainSpawner : MonoBehaviour
    {
        public int NumberOfTerrainObjects = 300;
        public GameObject TerrainObjectTemplate;

        public void SpawnNewTerrain()
        {
            ClearExistingTerrain();
            for (int i = 0; i < NumberOfTerrainObjects; i++)
            {
                var terrain = Instantiate(TerrainObjectTemplate, Util.RandomPosition(TestRunner.Instance.SpawnRadius),
                    Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up));
                terrain.transform.parent = transform;
            }
        }

        private void ClearExistingTerrain()
        {
            foreach (Transform child in transform)
            {
                DestroyImmediate(child.gameObject);
            }
        }
    }
}
