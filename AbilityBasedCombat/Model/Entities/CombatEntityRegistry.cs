using System.Collections.Generic;

namespace Andre.AbilityBasedCombat.Model
{
	// Concrete registry implementation.
	public sealed class CombatEntityRegistry : ICombatEntityRegistry
	{
		private readonly List<ICombatEntity> entities = new List<ICombatEntity>();

		public void Register(ICombatEntity entity)
		{
			if (entity == null)
				throw new System.ArgumentNullException(nameof(entity));

			if (!entities.Contains(entity))
				entities.Add(entity);
		}

		public void Unregister(ICombatEntity entity)
		{
			if (entity == null)
				throw new System.ArgumentNullException(nameof(entity));

			entities.Remove(entity);
		}

		public IReadOnlyList<ICombatEntity> GetAllEntities()
		{
			return entities.AsReadOnly();
		}
	}
}
