using Andre.AbilityBasedCombat;
using Andre.AbilityBasedCombat.Controller;
using Andre.AbilityBasedCombat.Model;
using Assets.Scripts.Demo.Abilities;
using UnityEngine;

namespace Andre.Demo
{
	// Composition root for the demo project.
	// Wires together the AbilityBasedCombat system,
	// registers demo entities, and initializes the simulation.
	public class Boot : MonoBehaviour
	{
		public void Awake()
		{
			var abilityExecutorLoggingDecorator = new AbilityExecutorLoggingDecorator(
				new AbilityExecutor(),
				new UnityDebugAbilityLogger());

			var combatEntityRegistry = new CombatEntityRegistry();

			var abilityBasedCombatSystem = new AbilityBasedCombatSystem(
				abilityExecutorLoggingDecorator,
				combatEntityRegistry);

			var abilityFactory = new AbilityFactory(
				new CombatEntityService(abilityBasedCombatSystem.CombatEntityRegistry),
				new NullPositionService(),
				new NullHealthService());

			var entityFactory = new EntityFactory(abilityFactory);

			abilityBasedCombatSystem.CombatEntityRegistry.Register(
				entityFactory.CreateBarbarianEntity());

			abilityBasedCombatSystem.CombatEntityRegistry.Register(
				entityFactory.CreateNecromancerEntity());

			new AssetFactory(
				abilityBasedCombatSystem.AbilityOrchestrator)
				.CreateCombatSimulation();
		}
	}
}
