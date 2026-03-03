using System.Collections.Generic;

namespace Andre.AbilityBasedCombat.Model
{
	// Basic entity interface. Contains triggers for abilities.
	public interface ICombatEntity {
		IReadOnlyList<IAbilityTrigger> AbilityTriggers { get; }
		void AddAbilityTrigger(IAbilityTrigger abilityTrigger);
	}
}
