namespace GamePrototype.Units
{
    public sealed class Goblin : Unit
    {
        public Goblin(string name, uint health, uint maxHealth, uint baseDamage, uint armour) : base(name, health, maxHealth, baseDamage, armour)
        {
        }

        public override uint GetUnitDamage() => BaseDamage;

        public override void HandleCombatComplete() => Health = MaxHealth;

        protected override uint CalculateAppliedDamage(uint damage) => damage;
    }
}
