namespace Andre.AbilityBasedCombat.Model
{
	// Condition interface: determines if an ability can affect a target.
	public interface ICondition
	{
		bool IsMet(AbilityContext context, ICombatEntity target);
	}
}
