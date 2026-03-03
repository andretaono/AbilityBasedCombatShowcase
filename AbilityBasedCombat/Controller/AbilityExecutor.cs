using Andre.AbilityBasedCombat.Model;
using System.Collections.Generic;
using System.Linq;

namespace Andre.AbilityBasedCombat.Controller
{
	// Executes an ability against its targets.
	// Handles: conditions, effect modifiers, and effects.
	// Stateless. Execution is isolated and deterministic.
	// Execution order: Targeting -> Conditions -> Modifiers -> Effects.
	public sealed class AbilityExecutor : IAbilityExecutor
	{
		public AbilityExecutionResult Execute(Ability ability, AbilityContext context)
		{
			var executionState = new AbilityExecutionState();

			foreach (var target in ResolveTargets(ability, context))
			{
				if (!ConditionsAreMet(ability, context, target))
					continue;

				ApplyAbilityEffects(ability, context, target, executionState);
			}

			return FinalizeResult(executionState);
		}

		private AbilityExecutionResult FinalizeResult(AbilityExecutionState executionState) 
		{
			return executionState.ToResult();
		}

		private IReadOnlyList<ICombatEntity> ResolveTargets(
			Ability ability, 
			AbilityContext context)
		{
			return ability.Targeting.SelectTargets(context);
		}

		private static void ApplyAbilityEffects(
			Ability ability,
			AbilityContext context,
			ICombatEntity target,
			AbilityExecutionState state)
		{
			foreach (var effect in ability.Effects)
			{
				float value = ApplyModifiers(ability, context, target);
				effect.Apply(new EffectContext(context, target, value));
				state.RegisterApplication(target, value);
			}
		}

		private static bool ConditionsAreMet(
			Ability ability,
			AbilityContext context,
			ICombatEntity target)
		{
			return ability.Conditions.All(c => c.IsMet(context, target));
		}

		private static float ApplyModifiers(
			Ability ability,
			AbilityContext context,
			ICombatEntity target)
		{
			float value = ability.BasePower;

			foreach (var modifier in ability.Modifiers)
			{
				if (modifier.Applies(context, target))
					value = modifier.Modify(context, target, value);
			}

			return value;
		}
	}
}
