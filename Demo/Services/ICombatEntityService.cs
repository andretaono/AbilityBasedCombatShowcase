using Andre.AbilityBasedCombat.Model;
using System.Collections.Generic;

namespace Andre.Demo
{
	public interface ICombatEntityService
	{
		IReadOnlyList<ICombatEntity> GetAllOtherEntities(ICombatEntity entity);
	}
}
