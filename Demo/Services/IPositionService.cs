using Andre.AbilityBasedCombat.Model;
using UnityEngine;

namespace Andre.Demo
{
	public interface IPositionService
	{
		Vector3 GetPosition(ICombatEntity entity);
		Vector3 GetForward(ICombatEntity entity);
	}
}
