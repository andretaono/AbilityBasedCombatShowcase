using Andre.AbilityBasedCombat.Model;
using UnityEngine;

namespace Andre.Demo
{
	public sealed class CriticalHitModifier : IEffectModifier
	{
		private readonly float critChance;
		private readonly float critMultiplier;

		public CriticalHitModifier(float critChance, float critMultiplier)
		{
			this.critChance = critChance;
			this.critMultiplier = critMultiplier;
		}

		public bool Applies(AbilityContext context, ICombatEntity target)
		{
			return Random.value <= critChance;
		}

		public float Modify(AbilityContext context, ICombatEntity target, float value)
		{
			return value * critMultiplier;
		}
	}

}
