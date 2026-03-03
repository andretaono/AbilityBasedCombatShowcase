using Andre.AbilityBasedCombat.Model;

namespace Andre.Demo
{
	public class HealthPercentBelowCondition : ICondition
	{
		private readonly float threshold;
		private readonly IHealthService healthService;

		public HealthPercentBelowCondition(
			float threshold, 
			IHealthService healthService)
		{
			this.threshold = threshold;
			this.healthService = healthService;
		}

		public bool IsMet(AbilityContext context, ICombatEntity target)
		{
			var health = healthService.GetHealth(target);
			var maxHealth = healthService.GetMaxHealth(target);
			
			return health / maxHealth < threshold;
		}
	}
}
