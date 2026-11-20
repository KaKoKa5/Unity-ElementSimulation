using Project.Scripts.Core.ElementSysteme;
using Project.Scripts.Core.ElementSysteme.RunTime;
using Runtime.Project.Scripts.Core;
using UnityEngine;

namespace Goblfin
{
	public class FrozenState : IElementState
	{
		private Health currentHealth;

		public void Enter(ElementSimulation element)
		{
			element.vfxManager.VfxState(VFXManager.States.frozen);
		}

		public void Update(ElementSimulation element)
		{
			if (element.Heat > 5f)
				element.ChangeState(new NormalState());
		}

		public void Exit(ElementSimulation element)
		{
		}
	}
}
