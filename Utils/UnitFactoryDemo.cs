using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Units;

namespace GamePrototype.Utils
{
    public class UnitFactoryDemo
    {
        public static Unit CreatePlayer(string name)
        {
            var player = new Player(name, 30, 30, 6, 3);
            player.AddItemToInventory(new Weapon(10, 15, "Золото"));
            player.AddItemToInventory(new HealthPotion("Зелье"));
            return player;
        }

        public static Unit CreateGoblinEnemy() => new Goblin(GameConstants.Goblin, 18, 18, 2, 0);
    }
}
