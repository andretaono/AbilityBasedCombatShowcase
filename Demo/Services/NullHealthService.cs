using Andre.AbilityBasedCombat.Model;

namespace Andre.Demo
{
	// Placeholder service for demonstration purposes.
	public class NullHealthService : IHealthService
	{
		public void ApplyDamage(ICombatEntity entity, float amount) { }

		public void ApplyDamageOverTime(ICombatEntity entity, float amount, float time) { }

		public float GetHealth(ICombatEntity entity)
		{
			return 100;
		}

		public float GetMaxHealth(ICombatEntity entity)
		{
			return 100;
		}
	}
}
