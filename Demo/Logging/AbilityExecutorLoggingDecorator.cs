using Andre.AbilityBasedCombat.Controller;
using Andre.AbilityBasedCombat.Model;

namespace Andre.Demo
{
	// Decorator for IAbilityExecutor that logs execution results.
	public sealed class AbilityExecutorLoggingDecorator : IAbilityExecutor
	{
		private readonly IAbilityExecutor decoratee;
		private readonly IAbilityLogger logger;

		public AbilityExecutorLoggingDecorator(
			IAbilityExecutor decoratee,
			IAbilityLogger logger)
		{
			this.decoratee = decoratee;
			this.logger = logger;
		}

		public AbilityExecutionResult Execute(
			Ability ability,
			AbilityContext context)
		{
			var result = decoratee.Execute(ability, context);

			logger.LogExecution(ability, context, result);

			return result;
		}
	}
}
