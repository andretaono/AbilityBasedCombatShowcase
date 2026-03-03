using System;
using System.Collections.Generic;
using System.Linq;

namespace Andre.AbilityBasedCombat.Model
{
	// Represents an ability definition.
	// Pure data object. Stateless and reusable.
	// Contains targeting rules, conditions, effects, and effect modifiers.
	public sealed class Ability
	{
		public float BasePower { get; }
		public ITargetingRule Targeting { get; }
		public IReadOnlyList<ICondition> Conditions { get; }
		public IReadOnlyList<IEffect> Effects { get; }
		public IReadOnlyList<IEffectModifier> Modifiers { get; }

		public Ability(
			float basePower,
			ITargetingRule targeting,
			IEnumerable<ICondition> conditions,
			IEnumerable<IEffect> effects,
			IEnumerable<IEffectModifier> modifiers)
		{
			BasePower = basePower;
			Targeting = targeting ?? throw new ArgumentNullException(nameof(targeting));
			Conditions = (conditions ?? throw new ArgumentNullException(nameof(conditions))).ToList();
			Effects = (effects ?? throw new ArgumentNullException(nameof(effects))).ToList();
			Modifiers = (modifiers ?? throw new ArgumentNullException(nameof(modifiers))).ToList();
		}
	}
}
