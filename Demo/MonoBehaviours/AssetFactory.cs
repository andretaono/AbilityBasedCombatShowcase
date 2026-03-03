using Andre.AbilityBasedCombat.Model;
using UnityEngine;

namespace Andre.Demo
{
	public class AssetFactory
	{
		private readonly AbilityOrchestrator abilityOrchestrator;

		public AssetFactory(AbilityOrchestrator abilityOrchestrator) 
		{
			this.abilityOrchestrator = abilityOrchestrator;
		}

		public void CreateCombatSimulation()
		{
			new GameObject().AddComponent<CombatSimulation>().Initialize(abilityOrchestrator);
		}
	}
}
