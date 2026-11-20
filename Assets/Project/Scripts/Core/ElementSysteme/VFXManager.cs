using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.Core.ElementSysteme
{
    public class VFXManager : MonoBehaviour
    {
        public enum States { smoke, fire, electric, frozen, normal }

        [System.Serializable]
        public struct StateVisual
        {
            public States state;
            public GameObject vfx;        
            public Material material;   
        }

        [SerializeField] private Renderer[] renderers;
        [SerializeField] private StateVisual[] visuals;

        private Material[][] originalMaterials;
        private Dictionary<States, StateVisual> map;

        private void Awake()
        {
            originalMaterials = new Material[renderers.Length][];
            for (int i = 0; i < renderers.Length; i++)
                originalMaterials[i] = renderers[i].sharedMaterials;

            map = new Dictionary<States, StateVisual>();
            foreach (StateVisual stateVisual in visuals) map[stateVisual.state] = stateVisual;
        }

        private void OnEnable() => VfxState(States.normal);

        public void VfxState(States state)
        {
            foreach (var stateVisual in visuals)
                if (stateVisual.vfx != null) stateVisual.vfx.SetActive(stateVisual.state == state);

            ApplyMaterial(state);
        }

        private void ApplyMaterial(States state)
        {
            bool hasOverride = map.TryGetValue(state, out var stateVisual) && stateVisual.material != null;

            for (int i = 0; i < renderers.Length; i++)
            {
                if (!hasOverride)
                {
                    renderers[i].sharedMaterials = originalMaterials[i];
                    continue;
                }

                Material[] mats = new Material[originalMaterials[i].Length];
                for (int m = 0; m < mats.Length; m++) mats[m] = stateVisual.material;
                renderers[i].sharedMaterials = mats;
            }
        }
    }
}