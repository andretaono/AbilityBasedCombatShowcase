using Andre.AbilityBasedCombat.Model;
using System.Collections.Generic;
using System.Linq;

namespace Andre.Demo
{
	internal class CombatEntityService : ICombatEntityService
	{
		private readonly ICombatEntityRegistry combatEntityRegistry;

		public CombatEntityService(ICombatEntityRegistry combatEntityRegistry) 
		{
			this.combatEntityRegistry = combatEntityRegistry;
		}

		public IReadOnlyList<ICombatEntity> GetAllOtherEntities(ICombatEntity entity)
		{
			if (entity == null)
				throw new System.ArgumentNullException(nameof(entity));

			return combatEntityRegistry.GetAllEntities()
				.Where(e => e != entity).ToList().AsReadOnly();
		}
	}
}
