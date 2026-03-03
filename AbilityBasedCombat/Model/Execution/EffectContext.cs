namespace Andre.AbilityBasedCombat.Model
{

	// Context provided to each effect during application.
	// Contains source, target, and the current power value.
	public sealed class EffectContext
	{
		public AbilityContext AbilityContext { get; }
		public ICombatEntity Source => AbilityContext.Source;
		public ICombatEntity Target { get; }
		public float Power { get; }

		public EffectContext(AbilityContext abilityContext, ICombatEntity target, float power)
		{
			AbilityContext = abilityContext;
			Target = target;
			Power = power;
		}
	}
}
