using Andre.AbilityBasedCombat.Model;

namespace Andre.Demo
{
	public class DamageOverTimeEffect : IEffect
	{
		private readonly IHealthService healthService;
		private readonly float time;
		private readonly float damage;

		public DamageOverTimeEffect(
			IHealthService healthService, 
			float time, 
			float damage) 
		{
			this.healthService = healthService;
			this.time = time;
			this.damage = damage;
		}

		public void Apply(EffectContext context)
		{
			healthService.ApplyDamageOverTime(context.Target, damage, time);
		}
	}
}
