using Andre.AbilityBasedCombat.Model;

namespace Andre.AbilityBasedCombat.Controller
{
	// This abstraction exists to:
	// - Allow decorators (e.g., logging, metrics, validation).
	// - Enable unit testing of the orchestrator via mocking.
	// - Provide a clear behavioral boundary for execution logic.
	public interface IAbilityExecutor
	{
		AbilityExecutionResult Execute(Ability ability, AbilityContext context);
	}
}	
