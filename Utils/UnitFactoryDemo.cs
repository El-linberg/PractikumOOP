using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Units;

namespace GamePrototype.Utils
{
    public abstract class UnitFactory
    {
        public abstract Unit CreateUnit(string UnitName);
    }


    public class PlayerFactory:UnitFactory
    {
        public override Unit CreateUnit(string name)
        {
            var player = new Player(name, 30, 30, 6, 3);
            player.AddItemToInventory(new Weapon(10, 15, "Золото"));
            player.AddItemToInventory(new HealthPotion("Зелье"));
            return player;
        }
    }
    public class EasyUnitFactory:UnitFactory
    {
        public override Unit CreateUnit(string UnitName)
        {
           return new Goblin(GameConstants.Goblin, 18, 18, 2, 0);
        }
    }
    public class HardUnitFactory : UnitFactory
    {
        public override Unit CreateUnit(string UnitName)
        {
            return new Goblin(GameConstants.Goblin, 36, 36, 5, 3);
        }
    }
}
