using Andre.AbilityBasedCombat.Model;

namespace Andre.Demo
{
	public sealed class DamageEffect : IEffect
	{
		private readonly IHealthService healthService;
		private readonly float multiplier;

		public DamageEffect(
			IHealthService healthService,
			float multiplier)
		{
			this.healthService = healthService;
		}

		public void Apply(EffectContext context)
		{
			var damage = context.Power * multiplier;
			healthService.ApplyDamage(context.Target, damage);
		}
	}

}
