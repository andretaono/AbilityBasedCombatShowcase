using Andre.AbilityBasedCombat.Controller;
using Andre.AbilityBasedCombat.Model;

namespace Andre.AbilityBasedCombat
{
	// Top-level system object that holds orchestrator and registry.
	// Provides a single entry point to initialize and interact with the system.
	public class AbilityBasedCombatSystem
	{
		public ICombatEntityRegistry CombatEntityRegistry { get; }
		public AbilityOrchestrator AbilityOrchestrator { get; }

		public AbilityBasedCombatSystem(
			IAbilityExecutor abilityExecutor, 
			ICombatEntityRegistry combatEntityRegistry) 
		{
			CombatEntityRegistry = combatEntityRegistry;

			AbilityOrchestrator = new AbilityOrchestrator(
				abilityExecutor,
				combatEntityRegistry);
		}
	}
}
