using Andre.AbilityBasedCombat.Model;
using UnityEngine;

namespace Andre.Demo
{
	// Placeholder service for demonstration purposes.
	public class NullPositionService : IPositionService
	{
		public Vector3 GetPosition(ICombatEntity entity) { return Vector3.zero; }
		public Vector3 GetForward(ICombatEntity entity) { return Vector3.one; }
	}
}
