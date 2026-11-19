using Project.Scripts.Core.ElementSysteme.RunTime;
using Project.Scripts.Core.ElementSysteme.RunTime.Data;

namespace Goblfin
{
	public struct ElectricityChannel : IElementChannel
	{
		public float Get(ElementSimulation element) => element.Electricity;
		public void Add(ElementSimulation element, float amount) => element.AddElectricity(amount);
		public float Rate(ElementSimulation element) =>  0.5f;
		public float Resistance(ElementData element) => element.ElectricalConduct;
		public float Set(ElementSimulation element, float value) => element.Electricity = value;
	}
}