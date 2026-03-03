using Andre.AbilityBasedCombat.Model;
using UnityEngine;

namespace Andre.Demo
{
	public class CombatSimulation : MonoBehaviour
	{
		private AbilityOrchestrator abilityOrchestrator;

		public void Initialize(AbilityOrchestrator abilityOrchestrator)
		{
			this.abilityOrchestrator = abilityOrchestrator;
		}

		private void Update()
		{
			abilityOrchestrator.Update();
		}
	}
}
