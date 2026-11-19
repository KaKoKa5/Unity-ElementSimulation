using Goblfin;
using Runtime.Project.Scripts.Core;
using UnityEngine;

namespace Project.Scripts.Core.ElementSysteme.RunTime.ElementState
{
	public class HotState : IElementState
	{
		public void Enter(ElementSimulation element)
		{
			Debug.Log("Entered HotState");
			element.vfxManager.VfxState(VFXManager.States.smoke);
		}

		public void Update(ElementSimulation element)
		{
			if (element.Heat > element.ElementData.GoBurnState)
			{
				element.ChangeState(new BurningState());
			}

			if (element.Heat <= element.ElementData.GoHotState)
			{
				element.ChangeState(new NormalState());
			}
		}

		public void Exit(ElementSimulation element)
		{
		}
	}
}