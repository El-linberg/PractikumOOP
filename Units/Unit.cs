using GamePrototype.Items.EconomicItems;

namespace GamePrototype.Units
{
    public abstract class Unit
    {
        private const int INVENTORY_SIZE = 3;
        private uint _health;
        private uint _maxHealth;
        protected uint BaseDamage;
        private uint _armour;
        protected Inventory Inventory;
        
        public string Name { get; private set; }
        public uint Health
        {
            get => _health;
            protected set => _health = value;
        }
        
        public uint Armour
        {
            get => _armour;
            protected set => _armour = value;
        }
        public uint MaxHealth => _maxHealth;

        protected Unit(string name, uint health, uint maxHealth, uint baseDamage, uint armour) 
        {
            Name = name;
            _health = health;
            _maxHealth = maxHealth;
            BaseDamage = baseDamage;
            Inventory = new Inventory(INVENTORY_SIZE);
            _armour = armour;
        }
        public void ApplyDamage(uint damage)
        {
            var damageApplied = CalculateAppliedDamage(damage);
            if (_armour > 0)
            {
                _armour -= 1;
                Console.WriteLine("Броня -1");
                if (_health < damageApplied || (_health - damageApplied) <= 0)
                {
                    _health = 0;
                }
                else
                {
                    _health -= damageApplied;
                }

                DamageReceiveHandler();
            }
            else
            {
                if (_health < damageApplied || (_health - damageApplied) <= 0)
                {
                    _health = 0;
                }
                else
                {
                    _health -= damageApplied;
                }

                DamageReceiveHandler();
            }
        }

        protected abstract uint CalculateAppliedDamage(uint damage);
        
        protected virtual void DamageReceiveHandler() {}
        
        public abstract uint GetUnitDamage();

        public abstract void HandleCombatComplete();

        public virtual void AddItemToInventory(Item item) 
        {
            if (!Inventory.TryAdd(item)) 
            {
                Console.WriteLine($"Инвентарь {Name} заполнен");
            }
        }

        public void AddItemsFromUnitToInventory(Unit unit)
        {
            for (int i = 0; i < unit.Inventory.Items.Count; i++) 
            {
                if (!Inventory.TryAdd(unit.Inventory.Items[i])) 
                {
                    //inventory is full
                    return;
                }
            }
        }
    }
}
