using System;
using System.Collections.Generic;

namespace Andre.AbilityBasedCombat.Model
{
	// Concrete data container for a combat entity.
	public sealed class CombatEntity : ICombatEntity
	{
		public IReadOnlyList<IAbilityTrigger> AbilityTriggers => abilityTriggers;

		private List<IAbilityTrigger> abilityTriggers = new List<IAbilityTrigger>();

		public void AddAbilityTrigger(IAbilityTrigger abilityTrigger)
		{
			abilityTriggers.Add(abilityTrigger);
		}
	}
}
