namespace Andre.AbilityBasedCombat.Model
{
	// Trigger interface: determines WHEN an ability should execute.
	// Separate from Ability itself to allow multiple triggers per ability.
	public interface IAbilityTrigger
	{
		Ability Ability { get; }
		bool IsTriggered();
	}
}
