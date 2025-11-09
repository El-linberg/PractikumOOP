using GamePrototype.Dungeon;
using GamePrototype.Items.EconomicItems;

namespace GamePrototype.Utils
{
    public static class DungeonBuilder
    {
        public static DungeonRoom BuildDungeon()
        {
            var enter = new DungeonRoom("Нажми энтер");
            var monsterRoom = new DungeonRoom("О нет, враг!", UnitFactoryDemo.CreateGoblinEnemy());
            var emptyRoom = new DungeonRoom("Пусто(");
            var lootRoom = new DungeonRoom("Золотишко", new Gold());
            var lootStoneRoom = new DungeonRoom("О, это точильный камень, полезная вещь", new Grindstone("Точильный камень"));
            var finalRoom = new DungeonRoom("Финал", new Grindstone("Точильный камень"));

            enter.TrySetDirection(Direction.Right, monsterRoom);
            enter.TrySetDirection(Direction.Left, emptyRoom);

            monsterRoom.TrySetDirection(Direction.Forward, lootRoom);
            monsterRoom.TrySetDirection(Direction.Left, emptyRoom);

            emptyRoom.TrySetDirection(Direction.Forward, lootStoneRoom);

            lootRoom.TrySetDirection(Direction.Forward, finalRoom);
            lootStoneRoom.TrySetDirection(Direction.Forward, finalRoom);

            return enter;
        }
    }
}
