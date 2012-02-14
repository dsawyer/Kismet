using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace KismetDataTypes
{
    public class Spawner : LevelObject
    {
        private int numberOfMonsters;
        public int NumMonsters
        {
            get { return numberOfMonsters; }
            set { numberOfMonsters = value; }
        }

        private string monsterType;
        public string MonsterType
        {
            get { return monsterType; }
            set { monsterType = value; }
        }

        public Spawner() {}

        public Spawner(int x, int y, int numMonsters, string monType)
        {
            Name = "Spawner";

            int posX = x - 16;
            int posY = y - 16;

            Position = new Vector2(posX, posY);
            BoundingBox = new Rectangle(posX, posY, 32, 32);
            NumMonsters = numMonsters;
            MonsterType = monType;
        }
    }
}
