using System.Collections.Generic;

namespace Andre.AbilityBasedCombat.Model
{
	// Registry interface for managing all combat entities in the system.
	public interface ICombatEntityRegistry
	{
		void Register(ICombatEntity entity);
		void Unregister(ICombatEntity entity);
		IReadOnlyList<ICombatEntity> GetAllEntities();
	}
}
