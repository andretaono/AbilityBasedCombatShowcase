namespace Andre.AbilityBasedCombat.Model
{
	// Effect modifier interface: adjusts an ability's power under conditions.
	public interface IEffectModifier
	{
		bool Applies(AbilityContext context, ICombatEntity target);
		float Modify(AbilityContext context, ICombatEntity target, float value);
	}
}
