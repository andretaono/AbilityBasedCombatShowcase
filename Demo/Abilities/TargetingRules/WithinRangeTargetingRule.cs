using Andre.AbilityBasedCombat.Model;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Andre.Demo
{
	public class WithinRangeTargetingRule : ITargetingRule
	{
		private readonly float radius;
		private readonly IPositionService positionService;
		private readonly ICombatEntityService combatEntityService;

		public WithinRangeTargetingRule(
			float radius,
			IPositionService positionService,
			ICombatEntityService combatEntityService)
		{
			this.radius = radius;
			this.positionService = positionService;
			this.combatEntityService = combatEntityService;
		}

		public IReadOnlyList<ICombatEntity> SelectTargets(AbilityContext context)
		{
			var sourceEntity = context.Source;
			var sourcePosition = positionService.GetPosition(sourceEntity);

			return combatEntityService
				.GetAllOtherEntities(sourceEntity)
				.Where(e => Vector3.Distance(positionService.GetPosition(e), sourcePosition) <= radius)
				.ToList();
		}
	}
}
