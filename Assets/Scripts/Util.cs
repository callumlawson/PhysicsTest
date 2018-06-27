using UnityEngine;

namespace Assets.Scripts
{
    public static class Util
    {

        public static Vector3 RandomPosition(int spawnRadius)
        {
            return new Vector3(Random.Range(-spawnRadius, spawnRadius), 1, Random.Range(-spawnRadius, spawnRadius));
        }
    }
}
