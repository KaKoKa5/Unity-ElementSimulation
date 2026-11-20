using System.Collections.Generic;
using Runtime.Project.Scripts.Core;
using UnityEngine;

namespace Project.Scripts.Core.ElementSysteme.RunTime.Data
{
    [CreateAssetMenu(fileName = "MaterialData")]
    public class ElementData : ScriptableObject
    {
	    [Header("Structure")] 
	    [field:SerializeField] public float AverageDegree{ get; private set; }
	    [Header("Influence Feu")]
	    [field: SerializeField]
	    public float FireResistance { get; private set; } = 15;

	    [field:SerializeField]public float FireHitPower { get; set; } = 5;
		
	    [Header("FireStateChange")]
	    [field: SerializeField] public float GoHotState { get; private set; } = 25;
	    [field: SerializeField] public float GoBurnState { get; private set; } = 65; 
        
        [Header("Influence Frozen")]
        [field:SerializeField] public float GoFrozenState{ get; private set; }
        [field:SerializeField]public float EvaporationSpeed{ get; private set; }
        
        [Header("Influence Electricity")]
        [field:SerializeField] public float GoElectrifyState{ get; private set; }
        [field:SerializeField]public float ElectricalConduct{ get; private set; }

        
        [field:SerializeField]public float MaxHealth{ get; private set; }
        [field:SerializeField]public bool IsLiquid{ get; private set; }

        [field:SerializeField]public GameObject BurnPrefab{ get; private set; }
        [field:SerializeField]public GameObject NormalPrefab{ get; private set; }
        [field:SerializeField]public GameObject FrozenPrefab{ get; private set; }
        
        [Header("Pool")]
        [field: SerializeField] public int PoolSize { get; private set; } = 8;

        

        public IEnumerable<GameObject> GetPoolPrefabs()
        {
	        if (BurnPrefab != null)   yield return BurnPrefab;
	        if (FrozenPrefab != null) yield return FrozenPrefab;
	        if (NormalPrefab != null) yield return NormalPrefab;
        }
        public GameObject GetDeathPrefab(DeathVisual visual) => visual switch
        {
	        DeathVisual.Frozen => FrozenPrefab,
	        DeathVisual.Burned => BurnPrefab,
	        _                  => NormalPrefab
        };
    }
}
