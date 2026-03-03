using Andre.AbilityBasedCombat.Model;
using UnityEngine;

namespace Andre.Demo
{
	public class UnityKeyDownAbilityTrigger : IAbilityTrigger
	{
		public Ability Ability { get; private set; }

		private readonly KeyCode keyCode;

		public UnityKeyDownAbilityTrigger(Ability ability, KeyCode keyCode)
		{
			Ability = ability;
			this.keyCode = keyCode;
		}

		public bool IsTriggered()
		{
			return Input.GetKeyDown(keyCode);
		}
	}
}
