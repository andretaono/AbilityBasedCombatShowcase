using Andre.AbilityBasedCombat.Model;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Andre.Demo
{
	public class ConeTargetingRule : ITargetingRule
	{
		private readonly float range;
		private readonly float angle;
		private readonly IPositionService positionService;
		private readonly ICombatEntityService combatEntityService; 

		public ConeTargetingRule(
			float range,
			float angle,
			IPositionService positionService,
			ICombatEntityService combatEntityService)
		{
			this.range = range;
			this.angle = angle;
			this.positionService = positionService;
			this.combatEntityService = combatEntityService;
		}

		public IReadOnlyList<ICombatEntity> SelectTargets(AbilityContext context)
		{
			var entities = combatEntityService.GetAllOtherEntities(context.Source);
			var origin = positionService.GetPosition(context.Source);
			var direction = positionService.GetForward(context.Source);

			var halfAngle = angle * 0.5f;

			return entities.Where(e =>
			{
				var toTarget = positionService.GetPosition(e) - origin;

				if (toTarget.magnitude > range)
					return false;

				var angleTo = Vector3.Angle(direction, toTarget);
				return angleTo <= halfAngle;
			}).ToList();
		}
	}
}
