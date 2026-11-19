using System;
using UnityEngine;

namespace Project.Scripts.Core.ElementSysteme
{
    public class VFXManager : MonoBehaviour
    {
        public enum States
        {
            smoke,
            fire,
            electric,
            normal,
        }
        [SerializeField] private GameObject smokeParticles;
        [SerializeField] private GameObject fireParticles;
        [SerializeField] private GameObject electricParticles;

        private void Start()
        {
            smokeParticles.SetActive(false);
            fireParticles.SetActive(false);
            electricParticles.SetActive(false);
        }

        public void VfxState(States state)
        {
            switch (state)
            {
                case States.smoke:
                    SetActiveVfx(smokeParticles);
                    break;
                case States.fire:
                    SetActiveVfx(fireParticles);
                    break;
                case States.electric:
                    SetActiveVfx(electricParticles);
                    break;
                case States.normal:
                    SetActiveVfx(null);
                    break;
            }
        }

        private void SetActiveVfx(GameObject activeTarget)
        {
            if (smokeParticles != null) smokeParticles.SetActive(smokeParticles == activeTarget);
            if (fireParticles != null) fireParticles.SetActive(fireParticles == activeTarget);
            if (electricParticles != null) electricParticles.SetActive(electricParticles == activeTarget);
        }
    }
}