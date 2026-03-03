using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Andre.AbilityBasedCombat.Controller;
using Andre.AbilityBasedCombat.Model;

namespace Andre.AbilityBasedCombat.Editor.Tests
{
	[TestFixture]
	public class AbilityExecutorTests
	{
		private AbilityExecutor executor;

		[SetUp]
		public void Setup()
		{
			executor = new AbilityExecutor();
		}

		[Test]
		public void Execute_WhenConditionPasses_AppliesEffect()
		{
			var target = new CombatEntity();
			var effect = new TrackingEffect();

			var ability = CreateAbility(
				basePower: 10,
				targets: new[] { target },
				effects: new[] { effect },
				conditions: new[] { new AlwaysTrueCondition() }
			);

			executor.Execute(ability, new AbilityContext(new CombatEntity()));

			Assert.AreEqual(1, effect.ApplyCount);
			Assert.AreEqual(10, effect.LastPower);
		}

		[Test]
		public void Execute_WhenConditionFails_DoesNotApplyEffect()
		{
			var target = new CombatEntity();
			var effect = new TrackingEffect();

			var ability = CreateAbility(
				basePower: 10,
				targets: new[] { target },
				effects: new[] { effect },
				conditions: new[] { new AlwaysFalseCondition() }
			);

			executor.Execute(ability, new AbilityContext(new CombatEntity()));

			Assert.AreEqual(0, effect.ApplyCount);
		}

		[Test]
		public void Execute_WithMultipleTargets_AppliesPerValidTarget()
		{
			var targetA = new CombatEntity();
			var targetB = new CombatEntity();
			var effect = new TrackingEffect();

			var ability = CreateAbility(
				basePower: 5,
				targets: new[] { targetA, targetB },
				effects: new[] { effect },
				conditions: new[] { new AlwaysTrueCondition() }
			);

			executor.Execute(ability, new AbilityContext(new CombatEntity()));

			Assert.AreEqual(2, effect.ApplyCount);
		}

		[Test]
		public void Execute_SkipsOnlyFailingTargets()
		{
			var targetA = new CombatEntity();
			var targetB = new CombatEntity();
			var effect = new TrackingEffect();

			var ability = CreateAbility(
				basePower: 5,
				targets: new[] { targetA, targetB },
				effects: new[] { effect },
				conditions: new ICondition[]
				{
					new ConditionalPerTargetCondition(targetB)
				}
			);

			executor.Execute(ability, new AbilityContext(new CombatEntity()));

			Assert.AreEqual(1, effect.ApplyCount);
		}

		[Test]
		public void Execute_AppliesModifier_WhenAppliesReturnsTrue()
		{
			var target = new CombatEntity();
			var effect = new TrackingEffect();

			var ability = CreateAbility(
				basePower: 10,
				targets: new[] { target },
				effects: new[] { effect },
				modifiers: new[] { new FlatModifier(5) }
			);

			executor.Execute(ability, new AbilityContext(new CombatEntity()));

			Assert.AreEqual(15, effect.LastPower);
		}

		[Test]
		public void Execute_DoesNotApplyModifier_WhenAppliesReturnsFalse()
		{
			var target = new CombatEntity();
			var effect = new TrackingEffect();

			var ability = CreateAbility(
				basePower: 10,
				targets: new[] { target },
				effects: new[] { effect },
				modifiers: new[] { new NonApplyingModifier(100) }
			);

			executor.Execute(ability, new AbilityContext(new CombatEntity()));

			Assert.AreEqual(10, effect.LastPower);
		}

		[Test]
		public void Execute_WithMultipleEffects_AppliesEachEffect()
		{
			var target = new CombatEntity();
			var effectA = new TrackingEffect();
			var effectB = new TrackingEffect();

			var ability = CreateAbility(
				basePower: 5,
				targets: new[] { target },
				effects: new[] { effectA, effectB }
			);

			executor.Execute(ability, new AbilityContext(new CombatEntity()));

			Assert.AreEqual(1, effectA.ApplyCount);
			Assert.AreEqual(1, effectB.ApplyCount);
		}

		private Ability CreateAbility(
			float basePower,
			IEnumerable<ICombatEntity> targets,
			IEnumerable<IEffect> effects,
			IEnumerable<ICondition> conditions = null,
			IEnumerable<IEffectModifier> modifiers = null)
		{
			return new Ability(
				basePower, 
				new FakeTargeting(targets),
				conditions?.ToList() ?? new List<ICondition>(),
				effects.ToList(), 
				modifiers?.ToList() ?? new List<IEffectModifier>());
		}

		private class FakeTargeting : ITargetingRule
		{
			private readonly IReadOnlyList<ICombatEntity> targets;

			public FakeTargeting(IEnumerable<ICombatEntity> targets)
			{
				this.targets = targets.ToList();
			}

			public IReadOnlyList<ICombatEntity> SelectTargets(AbilityContext context)
				=> targets;
		}

		private class TrackingEffect : IEffect
		{
			public int ApplyCount { get; private set; }
			public float LastPower { get; private set; }

			public void Apply(EffectContext context)
			{
				ApplyCount++;
				LastPower = context.Power;
			}
		}

		private class AlwaysTrueCondition : ICondition
		{
			public bool IsMet(AbilityContext context, ICombatEntity target) => true;
		}

		private class AlwaysFalseCondition : ICondition
		{
			public bool IsMet(AbilityContext context, ICombatEntity target) => false;
		}

		private class ConditionalPerTargetCondition : ICondition
		{
			private readonly ICombatEntity invalidTarget;

			public ConditionalPerTargetCondition(ICombatEntity invalidTarget)
			{
				this.invalidTarget = invalidTarget;
			}

			public bool IsMet(AbilityContext context, ICombatEntity target)
				=> target != invalidTarget;
		}

		private class FlatModifier : IEffectModifier
		{
			private readonly float amount;

			public FlatModifier(float amount) => this.amount = amount;

			public bool Applies(AbilityContext context, ICombatEntity target) => true;

			public float Modify(AbilityContext context, ICombatEntity target, float value)
				=> value + amount;
		}

		private class MultiplyModifier : IEffectModifier
		{
			private readonly float multiplier;

			public MultiplyModifier(float multiplier) => this.multiplier = multiplier;

			public bool Applies(AbilityContext context, ICombatEntity target) => true;

			public float Modify(AbilityContext context, ICombatEntity target, float value)
				=> value * multiplier;
		}

		private class NonApplyingModifier : IEffectModifier
		{
			private readonly float amount;

			public NonApplyingModifier(float amount) => this.amount = amount;

			public bool Applies(AbilityContext context, ICombatEntity target) => false;

			public float Modify(AbilityContext context, ICombatEntity target, float value)
				=> value + amount;
		}
	}
}