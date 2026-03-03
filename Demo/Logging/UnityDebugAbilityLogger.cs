using Andre.AbilityBasedCombat.Model;

namespace Andre.Demo
{
	public sealed class UnityDebugAbilityLogger : IAbilityLogger
	{
		public void LogExecution(
			Ability ability, 
			AbilityContext context, 
			AbilityExecutionResult result)
		{
			UnityEngine.Debug.Log(
				FormatAbilityExecutionLog(ability, context, result));
		}

		private string FormatAbilityExecutionLog(
			Ability ability,
			AbilityContext context,
			AbilityExecutionResult result)
		{
			var sb = new System.Text.StringBuilder();

			sb.AppendLine($"[Ability Execution] Ability: {ability.GetType().Name}");
			sb.AppendLine($"Source: {context.Source}");
			sb.AppendLine($"Total Value Applied: {result.TotalValueApplied}");

			if (result.AffectedTargets.Count > 0)
			{
				sb.AppendLine("Affected Targets:");
				foreach (var target in result.AffectedTargets)
				{
					sb.AppendLine($"  - {target}");
				}
			}
			else
			{
				sb.AppendLine("Affected Targets: None");
			}

			return sb.ToString();
		}
	}
}
