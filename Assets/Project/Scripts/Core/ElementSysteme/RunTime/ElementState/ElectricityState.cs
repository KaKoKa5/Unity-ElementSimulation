using Goblfin;
using Runtime.Project.Scripts.Core;
using UnityEngine;

namespace Project.Scripts.Core.ElementSysteme.RunTime.ElementState
{
    public class ElectricityState : IElementState
    {
        private const float PropagationInterval = 0.1f;
        private float nextPropagationTime;
        private bool isElectrifying;

        public void Enter(ElementSimulation element)
        {
            Debug.Log("Electricity State");
            nextPropagationTime = Time.time;
            element.vfxManager?.VfxState(VFXManager.States.electric);
        }

        public void Update(ElementSimulation element)
        {
            if (element.Electricity <= element.ElementData.Electrify)
            {
                element.ChangeState(new NormalState());
                return;
            }

            isElectrifying = element.Electricity >= element.ElementData.Electrify;

            if (Time.time >= nextPropagationTime)
            {
                nextPropagationTime = Time.time + PropagationInterval;
                element.ElectricityPropagation();
            }

            if (isElectrifying && element.Humidity > 50f)
            {
                element.AddHeat(5f * Time.deltaTime);
            }
        }

        public void Exit(ElementSimulation element)
        {
            isElectrifying = false;
            element.vfxManager?.VfxState(VFXManager.States.normal);
        }
    }
}