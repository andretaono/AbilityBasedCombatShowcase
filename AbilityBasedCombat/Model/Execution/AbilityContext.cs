namespace Andre.AbilityBasedCombat.Model
{

	// Minimal per-execution state.
	// Represents the "source" of an ability execution.
	// Context should remain explicit and minimal.
	// No services or shared state.
	public class AbilityContext
	{
		public ICombatEntity Source { get; }

		public AbilityContext(ICombatEntity source)
		{
			Source = source;
		}
	}
}
