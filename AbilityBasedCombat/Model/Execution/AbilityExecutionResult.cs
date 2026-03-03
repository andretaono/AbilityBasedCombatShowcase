using System.Collections.Generic;

namespace Andre.AbilityBasedCombat.Model
{

	// Represents the result of executing an ability.
	// Contains targets affected and total value applied.
	public sealed class AbilityExecutionResult
	{
		public IReadOnlyList<ICombatEntity> AffectedTargets { get; }
		public float TotalValueApplied { get; }

		internal AbilityExecutionResult(
			IReadOnlyList<ICombatEntity> affectedTargets,
			float totalValueApplied)
		{
			AffectedTargets = affectedTargets;
			TotalValueApplied = totalValueApplied;
		}
	}
}
