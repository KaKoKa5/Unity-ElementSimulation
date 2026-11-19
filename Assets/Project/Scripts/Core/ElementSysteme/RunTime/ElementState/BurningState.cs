using Project.Scripts.Core.ElementSysteme;
using Project.Scripts.Core.ElementSysteme.RunTime;
using Project.Scripts.Core.ElementSysteme.RunTime.ElementState;
using Runtime.Project.Scripts.Core;
using UnityEngine;

namespace Goblfin
{
	public class BurningState: IElementState
	{
		private Health currentHealth;
		public void Enter(ElementSimulation element)
		{
			Debug.Log("Entering BurningState");
			element.vfxManager.VfxState(VFXManager.States.fire);
			currentHealth = element.GetInfo<Health>();
			currentHealth.SetDeathVisual(DeathVisual.Burned);
			ProblemRegistry.RegisterProblem(element, TypeOfProblem.Burn);
		}

		public void Update(ElementSimulation element)
		{
			currentHealth.TakeDamageEnv(element.ElementData.FireHitPower);
			element.FirePropagation();
			if (element.Heat <= element.ElementData.GoBurnState)
			{
				
				element.ChangeState(new HotState());
			}
		}

		public void Exit(ElementSimulation element)
		{
			
		}
	}
}