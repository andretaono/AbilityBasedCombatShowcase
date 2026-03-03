using Andre.AbilityBasedCombat.Model;

namespace Andre.Demo
{
	public interface IAbilityLogger
	{
		void LogExecution(
			Ability ability,
			AbilityContext context,
			AbilityExecutionResult result);
	}
}
