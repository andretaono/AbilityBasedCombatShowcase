using System.Collections.Generic;

namespace Andre.AbilityBasedCombat.Model
{
	// Targeting rule interface: determines which entities are targeted by an ability.
	public interface ITargetingRule
	{
		IReadOnlyList<ICombatEntity> SelectTargets(AbilityContext context);
	}
}
