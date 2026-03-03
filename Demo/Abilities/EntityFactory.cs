using Andre.AbilityBasedCombat.Model;
using Andre.Demo;

namespace Assets.Scripts.Demo.Abilities
{
	public class EntityFactory
	{
		private readonly AbilityFactory abilityFactory;

		public EntityFactory(AbilityFactory abilityFactory) 
		{
			this.abilityFactory = abilityFactory;
		}

		public ICombatEntity CreateBarbarianEntity()
		{
			var slamAbilityTrigger = new UnityKeyDownAbilityTrigger(
				abilityFactory.CreateSlamAbility(),
				UnityEngine.KeyCode.Alpha1);

			var entity = new CombatEntity();
			entity.AddAbilityTrigger(slamAbilityTrigger);

			return entity;
		}

		public ICombatEntity CreateNecromancerEntity()
		{
			var poisonCloudAbilityTrigger = new UnityKeyDownAbilityTrigger(
			abilityFactory.CreatePoisonCloudAbility(),
			UnityEngine.KeyCode.Alpha2);

			var entity = new CombatEntity();
			entity.AddAbilityTrigger(poisonCloudAbilityTrigger);

			return entity;
		}
	}
}
