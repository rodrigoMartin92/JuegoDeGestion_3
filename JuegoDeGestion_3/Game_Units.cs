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

        public Game_Building(string Building_Name, int Building_HitPoints, int Building_Resource1_Cost)
        {
            ID = Guid.NewGuid();
            Building_Name = Building_Name;
            Building_HitPoints = Building_HitPoints;
            Building_HitPoints_Remaining = Building_HitPoints;
            Building_Resource1_Cost = Building_Resource1_Cost;
            Building_Quality = 1;
        }
        public void Improve_Quality() { Building_Quality += 1; }
    }
    internal class Building_Main_Fortress : Game_Building { public Building_Main_Fortress() : base(
            (string)BaseDeDatos.Buildings[0][0],   // Building_Name
            (int)BaseDeDatos.Buildings[0][1],      // Building_HitPoints
            (int)BaseDeDatos.Buildings[0][5]      // Building_Resource1_Cost
        ) { } }
    internal class Building_Resource1Gathering : Game_Building { public Building_Resource1Gathering() : base(
            (string)BaseDeDatos.Buildings[1][0],   // Building_Name
            (int)BaseDeDatos.Buildings[1][1],      // Building_HitPoints
            (int)BaseDeDatos.Buildings[1][5]      // Building_Resource1_Cost
        ) { } }
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
        public Game_Troops(
            string name,
            int HitPoints,
            int FoodConsumption,
            int TroopDamage,
            int TroopNumberOfAttacks,
            int resourceCost)
        {
            ID = Guid.NewGuid();
            Troop_Name = name;
            Troop_Resource1_Cost = resourceCost;
            Troop_HitPoints = HitPoints;
            Troop_HitPoints_Remaining = HitPoints;
            Food_Consumption = FoodConsumption;
            Troop_Damage = TroopDamage;
            Troop_NumberOfAttacks = TroopNumberOfAttacks;
        }
    }
    internal class Troop_Basic1 : Game_Troops
    {
        public Troop_Basic1() : base(
            (string)BaseDeDatos.Troops[0][0],   // Troop_Name
            (int)BaseDeDatos.Troops[0][1],      // Troop_HitPoints
            (int)BaseDeDatos.Troops[0][5],      // Food_Consumption
            (int)BaseDeDatos.Troops[0][2],      // Troop_Damage
            (int)BaseDeDatos.Troops[0][3],      // Troop_NumberOfAttacks
            (int)BaseDeDatos.Troops[0][4]       // Troop_Resource1_Cost
            ) { }
    }

    internal class Troop_Advanced1 : Game_Troops 
    { 
        public Troop_Advanced1() : base(
            (string)BaseDeDatos.Troops[1][0],   // Troop_Name
            (int)BaseDeDatos.Troops[1][1],      // Troop_HitPoints
            (int)BaseDeDatos.Troops[1][5],      // Food_Consumption
            (int)BaseDeDatos.Troops[1][2],      // Troop_Damage
            (int)BaseDeDatos.Troops[1][3],      // Troop_NumberOfAttacks
            (int)BaseDeDatos.Troops[1][4]       // Troop_Resource1_Cost
        ) { } 
    }
    public class Game_Enemies
    {
        public Guid ID { get; set; }
        public string Enemy_Name { get; set; }
        public int Enemy_HitPoints { get; set; }
        public int Enemy_HitPoints_Remaining { get; set; }
        public int Enemy_Damage { get; set; }
        public int Enemy_NumberOfAttacks { get; set; }
        public int Enemy_CreationCost { get; set; }
        public Game_Enemies(
            string Enemy_Name,
            int Enemy_HitPoints,
            int Enemy_Damage,
            int Enemy_NumberOfAttacks,
            int Enemy_CreationCost
            )
        {
            ID = Guid.NewGuid();
            Enemy_Name = Enemy_Name;
            Enemy_HitPoints = Enemy_HitPoints;
            Enemy_HitPoints_Remaining = Enemy_HitPoints;
            Enemy_Damage = Enemy_Damage;
            Enemy_NumberOfAttacks = Enemy_NumberOfAttacks; 
            Enemy_CreationCost = Enemy_CreationCost;
        }
    }
    internal class Enemy_Basic1 : Game_Enemies
    { public Enemy_Basic1() : base(
            (string)BaseDeDatos.Enemies[0][0],  // Enemy_Name
            (int)BaseDeDatos.Enemies[0][1],     // Enemy_HitPoints
            (int)BaseDeDatos.Enemies[0][5],     // Enemy_Damage
            (int)BaseDeDatos.Enemies[0][2],     // Enemy_NumberOfAttacks
            (int)BaseDeDatos.Enemies[0][3]      // Enemy_CreationCost
        ) { } }
    internal class Enemy_Advanced1 : Game_Enemies
    { public Enemy_Advanced1() : base(
            (string)BaseDeDatos.Enemies[1][0],  // Enemy_Name
            (int)BaseDeDatos.Enemies[1][1],     // Enemy_HitPoints
            (int)BaseDeDatos.Enemies[1][5],     // Enemy_Damage
            (int)BaseDeDatos.Enemies[1][2],     // Enemy_NumberOfAttacks
            (int)BaseDeDatos.Enemies[1][3]      // Enemy_CreationCost
        ) { } }
}
