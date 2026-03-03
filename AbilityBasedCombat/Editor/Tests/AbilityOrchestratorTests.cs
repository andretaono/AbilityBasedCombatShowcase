using Andre.AbilityBasedCombat.Controller;
using Andre.AbilityBasedCombat.Model;
using NUnit.Framework;
using System.Collections.Generic;

namespace Andre.AbilityBasedCombat.Editor.Tests
{
	[TestFixture]
	public class AbilityOrchestratorTests
	{
		private FakeExecutor executor;
		private CombatEntityRegistry registry;
		private AbilityOrchestrator orchestrator;

		[SetUp]
		public void Setup()
		{
			executor = new FakeExecutor();
			registry = new CombatEntityRegistry();
			orchestrator = new AbilityOrchestrator(executor, registry);
		}

		[Test]
		public void Update_WhenTriggerIsTriggered_CallsExecutor()
		{
			var ability = CreateAbility();
			var entity = new CombatEntity();
			entity.AddAbilityTrigger(new FakeTrigger(ability, shouldTrigger: true));

			registry.Register(entity);

			orchestrator.Update();

			Assert.AreEqual(1, executor.CallCount);
			Assert.AreSame(ability, executor.LastAbility);
			Assert.AreSame(entity, executor.LastContext.Source);
		}

		[Test]
		public void Update_WhenTriggerIsNotTriggered_DoesNotCallExecutor()
		{
			var ability = CreateAbility();
			var entity = new CombatEntity();
			entity.AddAbilityTrigger(new FakeTrigger(ability, shouldTrigger: false));

			registry.Register(entity);

			orchestrator.Update();

			Assert.AreEqual(0, executor.CallCount);
		}

		[Test]
		public void Update_WithMultipleTriggers_CallsExecutorOnlyForTriggeredOnes()
		{
			var abilityA = CreateAbility();
			var abilityB = CreateAbility();

			var entity = new CombatEntity();
			entity.AddAbilityTrigger(new FakeTrigger(abilityA, shouldTrigger: true));
			entity.AddAbilityTrigger(new FakeTrigger(abilityB, shouldTrigger: false));

			registry.Register(entity);

			orchestrator.Update();

			Assert.AreEqual(1, executor.CallCount);
			Assert.AreSame(abilityA, executor.LastAbility);
		}

		[Test]
		public void Update_WithMultipleEntities_ProcessesAllEntities()
		{
			var abilityA = CreateAbility();
			var abilityB = CreateAbility();

			var entityA = new CombatEntity();
			entityA.AddAbilityTrigger(new FakeTrigger(abilityA, shouldTrigger: true));

			var entityB = new CombatEntity();
			entityB.AddAbilityTrigger(new FakeTrigger(abilityB, shouldTrigger: true));

			registry.Register(entityA);
			registry.Register(entityB);

			orchestrator.Update();

			Assert.AreEqual(2, executor.CallCount);
		}

		[Test]
		public void Update_WhenNoEntities_DoesNothing()
		{
			orchestrator.Update();

			Assert.AreEqual(0, executor.CallCount);
		}

		private Ability CreateAbility()
		{
			return new Ability(
				0,
				new FakeTargetingRule(),
				new List<ICondition>(),
				new List<IEffect>(),
				new List<IEffectModifier>());
		}

		private class FakeExecutor : IAbilityExecutor
		{
			public int CallCount { get; private set; }
			public Ability LastAbility { get; private set; }
			public AbilityContext LastContext { get; private set; }

			public AbilityExecutionResult Execute(Ability ability, AbilityContext context)
			{
				CallCount++;
				LastAbility = ability;
				LastContext = context;
				return null;
			}
		}

		private class FakeTrigger : IAbilityTrigger
		{
			private readonly bool shouldTrigger;

			public Ability Ability { get; }

			public FakeTrigger(Ability ability, bool shouldTrigger)
			{
				Ability = ability;
				this.shouldTrigger = shouldTrigger;
			}

			public bool IsTriggered() => shouldTrigger;
		}

		private class FakeTargetingRule : ITargetingRule
		{
			public IReadOnlyList<ICombatEntity> SelectTargets(AbilityContext context)
			{
				return new List<ICombatEntity>();
			}
		}
	}
}