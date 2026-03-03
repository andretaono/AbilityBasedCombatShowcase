using Andre.AbilityBasedCombat.Controller;
using System.Collections.Generic;

namespace Andre.AbilityBasedCombat.Model
{
	// Responsible for scheduling abilities each frame or turn.
	// Project is responsible for handling update timing.
	// Calls IAbilityExecutor.Execute when triggers are active.
	// Does NOT handle the execution logic itself.
	public sealed class AbilityOrchestrator
	{
		private readonly IAbilityExecutor abilityExecutor;
		private readonly ICombatEntityRegistry combatEntityRegistry;

		public AbilityOrchestrator(
			IAbilityExecutor abilityExecutor,
			ICombatEntityRegistry combatEntityRegistry) 
		{
			this.abilityExecutor = abilityExecutor;
			this.combatEntityRegistry = combatEntityRegistry;
		}

		public void Update()
		{
			IterateEntities(combatEntityRegistry.GetAllEntities());
		}

		private void IterateEntities(IEnumerable<ICombatEntity> entities)
		{
			foreach (var entity in entities)
			{
				IterateAbilities(entity);
			}
		}

		private void IterateAbilities(ICombatEntity entity)
		{
			foreach (var trigger in entity.AbilityTriggers)
			{
				if (!trigger.IsTriggered())
					continue;
				
				abilityExecutor.Execute(
					trigger.Ability,
					new AbilityContext(entity));
			}
		}
	}
}
