namespace Andre.AbilityBasedCombat.Model
{
	// Effect interface: defines what happens to a target when an ability is applied.
	public interface IEffect
	{
		void Apply(EffectContext context);
	}
}
