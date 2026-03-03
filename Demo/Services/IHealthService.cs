using Andre.AbilityBasedCombat.Model;

namespace Andre.Demo
{
	public interface IHealthService
	{
		void ApplyDamage(ICombatEntity entity, float amount);
		void ApplyDamageOverTime(ICombatEntity entity, float amount, float time);
		float GetHealth(ICombatEntity entity);
		float GetMaxHealth(ICombatEntity entity);
	}
}
