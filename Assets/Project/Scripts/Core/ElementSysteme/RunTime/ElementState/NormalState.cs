using Project.Scripts.Core.ElementSysteme;
using Project.Scripts.Core.ElementSysteme.RunTime;
using Project.Scripts.Core.ElementSysteme.RunTime.ElementState;
using Runtime.Project.Scripts.Core;
using UnityEngine;
using UnityEngine.Audio;

namespace Goblfin
{
    public class NormalState : IElementState
    {
	    private Health currentHealth;
	    
        public void Enter(ElementSimulation element)
        {
            element.vfxManager.VfxState(VFXManager.States.normal);
            ProblemRegistry.UnregisterProblem(element,TypeOfProblem.Burn);
        }

        public void Update(ElementSimulation element)
        {
            if (element.Heat > element.ElementData.GoHotState)
            {
                element.ChangeState(new HotState());
            }
            
            if (element.Humidity > element.ElementData.GoFrozenState)
            {
                if (!element.ElementData.IsLiquid)
                {
                    element.Collider.isTrigger = false;
                }
                element.ChangeState(new FrozenState());
            }
            if (element.Electricity > element.ElementData.GoElectrifyState)
                element.ChangeState(new ElectricityState());
        }

        public void Exit(ElementSimulation element)
        {
        }
    }
}
