using System.Collections.Generic;
using Goblfin;
using Project.Scripts.Core.ElementSysteme.RunTime.Data;
using UnityEngine;

namespace Project.Scripts.Core.ElementSysteme.RunTime.PoolObjectSysteme
{
    public class PoolManager : MonoBehaviour
    {
        [Header("Scan")]
        [SerializeField] private int maxPerPrefab = 64;

        private void Start()
        {
            var needed = new Dictionary<GameObject, int>();

            CountElementPrefabs(needed);

            foreach (var (prefab, count) in needed)
                PrefabPool.Prewarm(prefab, Mathf.Min(count, maxPerPrefab));
        }

        private static void CountElementPrefabs(Dictionary<GameObject, int> needed)
        {
            var sims = FindObjectsByType<ElementSimulation>(FindObjectsInactive.Include, FindObjectsSortMode.None);

            var perData = new Dictionary<ElementData, int>();
            foreach (ElementSimulation sim in sims)
            {
                if (sim.ElementData == null) continue;
                perData[sim.ElementData] = perData.GetValueOrDefault(sim.ElementData) + 1;
            }

            foreach (var (data, simCount) in perData)
            {
                int count = Mathf.Clamp(simCount, 1, data.PoolSize);
                foreach (GameObject prefab in data.GetPoolPrefabs())
                    needed[prefab] = needed.GetValueOrDefault(prefab) + count;
            }
        }
    }
}