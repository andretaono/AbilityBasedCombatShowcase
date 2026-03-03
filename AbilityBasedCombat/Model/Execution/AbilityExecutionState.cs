using System.Collections.Generic;

namespace Andre.AbilityBasedCombat.Model
{

	// Internal helper to accumulate execution state per ability execution.
	internal sealed class AbilityExecutionState
	{
		public float TotalValueApplied { get; private set; }
		public IReadOnlyList<ICombatEntity> AffectedTargets => affectedTargets;

		private readonly List<ICombatEntity> affectedTargets = new();

		public void RegisterApplication(ICombatEntity target, float value)
		{
			if (!affectedTargets.Contains(target))
				affectedTargets.Add(target);

			TotalValueApplied += value;
		}

		public AbilityExecutionResult ToResult()
		{
			return new AbilityExecutionResult(
				affectedTargets.AsReadOnly(),
				TotalValueApplied);
		}
	}
}
