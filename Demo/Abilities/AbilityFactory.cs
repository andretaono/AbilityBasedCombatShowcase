using Andre.AbilityBasedCombat.Model;
using System.Collections.Generic;

namespace Andre.Demo
{
	// Editor tooling can be added later on and this class can be modified to load necessary ability definitions.
	public class AbilityFactory
	{
		private readonly ICombatEntityService combatEntityService;
		private readonly IPositionService positionService;
		private readonly IHealthService healthService;

		public AbilityFactory(
			ICombatEntityService combatEntityService,
			IPositionService positionService,
			IHealthService healthService) 
		{
			this.combatEntityService = combatEntityService;
			this.positionService = positionService;
			this.healthService = healthService;
		}

		public Ability CreateSlamAbility()
		{
			var ability = new Ability(
				15,
				new ConeTargetingRule(4, 90, positionService, combatEntityService),
				new List<ICondition>() { new HealthPercentBelowCondition(0.3f, healthService) },
				new List<IEffect>() { new DamageEffect(healthService, 1.5f) },
				new List<IEffectModifier>() { new CriticalHitModifier(0.1f, 2) }
			);

			return ability;
		}

		public Ability CreatePoisonCloudAbility() 
		{
			var ability = new Ability(
				20,
				new WithinRangeTargetingRule(6, positionService, combatEntityService),
				new List<ICondition>() { },
				new List<IEffect>() { new DamageOverTimeEffect(healthService, 1.5f, 30) },
				new List<IEffectModifier>() { }
			);

			return ability;
		}
	}
}
