using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoDeGestion_3
{
    internal class Game_Building
    {
        public Guid ID { get; set; }
        public string Building_Name { get; set; }
        public int Building_HitPoints { get; set; }
        public int Building_HitPoints_Remaining { get; set; }
        public int Building_Resource1_Cost { get; set; }
        public int Building_Quality { get; set; }

        public Game_Building(string name, int HitPoints, int resourceCost)
        {
            ID = Guid.NewGuid();
            Building_Name = name;
            Building_HitPoints = HitPoints;
            Building_HitPoints_Remaining = HitPoints;
            Building_Resource1_Cost = resourceCost;
            Building_Quality = 1;
        }
        public void Improve_Quality() { Building_Quality += 1; }
    }
    internal class Building_Main_Fortress : Game_Building { public Building_Main_Fortress() : base("Main Fortress", 1000, 200) { } }
    internal class Building_Resource1Gathering : Game_Building { public Building_Resource1Gathering() : base("Wood Gathering", 500, 100) { } }
    public class Game_Troops
    {
        public Guid ID { get; set; }
        public string Troop_Name { get; set; }
        public int Troop_HitPoints { get; set; }
        public int Troop_HitPoints_Remaining { get; set; }
        public int Troop_Damage { get; set; }
        public int Troop_NumberOfAttacks { get; set; }
        public int Food_Consumption { get; set; }
        public int Troop_Resource1_Cost { get; set; }
        public Game_Troops(string name, int HitPoints, int FoodConsumption, int TroopDamage, int TroopNumberOfAttacks, int resourceCost)
        {
            ID = Guid.NewGuid(); Troop_Name = name; Troop_Resource1_Cost = resourceCost; Troop_HitPoints = HitPoints; Troop_HitPoints_Remaining = HitPoints;
            Food_Consumption = FoodConsumption; Troop_Damage = TroopDamage; Troop_NumberOfAttacks = TroopNumberOfAttacks;
        }
    }
    internal class Troop_Basic1 : Game_Troops { public Troop_Basic1() : base("Basic troop", 150, 20, 10, 5, 10) { } }
    internal class Troop_Advanced1 : Game_Troops { public Troop_Advanced1() : base("Basic troop", 150, 20, 10, 5, 30) { } }
    public class Game_Enemies
    {
        public Guid ID { get; set; }
        public string Enemy_Name { get; set; }
        public int Enemy_HitPoints { get; set; }
        public int Enemy_HitPoints_Remaining { get; set; }
        public int Enemy_Damage { get; set; }
        public int Enemy_NumberOfAttacks { get; set; }
        public int Enemy_CreationCost { get; set; }
        public Game_Enemies(string name, int HitPoints, int EnemyDamage, int EnemyNumberOfAttacks, int EnemyValue)
        {
            ID = Guid.NewGuid(); Enemy_Name = name; Enemy_HitPoints = HitPoints; Enemy_HitPoints_Remaining = HitPoints;
            Enemy_Damage = EnemyDamage; Enemy_NumberOfAttacks = EnemyNumberOfAttacks; Enemy_CreationCost = EnemyValue;
        }
    }
    internal class Enemy_Basic1 : Game_Enemies
    { public Enemy_Basic1() : base("Basic Enemy", 150, 5, 20, 10) { } }
    internal class Enemy_Advanced1 : Game_Enemies
    { public Enemy_Advanced1() : base("Basic Enemy", 250, 15, 20, 30) { } }
}
