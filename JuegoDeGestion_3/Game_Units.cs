using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoDeGestion_3
{
    public class Game_Building
    {
        public Guid ID { get; set; }
        public string Building_Name { get; set; }
        public int Building_HitPoints { get; set; }
        public int Building_HitPoints_Remaining { get; set; }
        public int Building_Resource1_Cost { get; set; }
        public int Building_Quality { get; set; }

        public Game_Building(string Building_Name_, int Building_HitPoints_, int Building_Resource1_Cost_)
        {
            ID = Guid.NewGuid();
            Building_Name = Building_Name_;
            Building_HitPoints = Building_HitPoints_;
            Building_HitPoints_Remaining = Building_HitPoints_;
            Building_Resource1_Cost = Building_Resource1_Cost_;
            Building_Quality = 1;
        }
        public void Improve_Quality() { Building_Quality += 1; }
    }
    internal class Building_Main_Fortress : Game_Building { public Building_Main_Fortress() : base(
            (string)BaseDeDatos.Buildings[0][0],    // Building_Name
            (int)BaseDeDatos.Buildings[0][1],       // Building_HitPoints
            (int)BaseDeDatos.Buildings[0][2]        // Building_Resource1_Cost
        ) { }
    }

    internal class Building_Resource1Gathering : Game_Building { public Building_Resource1Gathering() : base(
            (string)BaseDeDatos.Buildings[1][0],    // Building_Name
            (int)BaseDeDatos.Buildings[1][1],       // Building_HitPoints
            (int)BaseDeDatos.Buildings[1][2]        // Building_Resource1_Cost
        ) { } }
    public class Game_Troops
    {
        public Guid ID { get; set; }
        public string Troop_Name { get; set; }
        public int Troop_HitPoints { get; set; }
        public int Troop_HitPoints_Remaining { get; set; }
        public int Troop_Damage { get; set; }
        public int Troop_NumberOfAttacks { get; set; }
        public int Troop_Food_Consumption { get; set; }
        public int Troop_Resource1_Cost { get; set; }
        public Game_Troops(
            string Troop_Name_,
            int Troop_HitPoints_,
            int Troop_Food_Consumption_,
            int Troop_Damage_,
            int Troop_NumberOfAttacks_,
            int Troop_Resource1_Cost_)
        {
            ID = Guid.NewGuid();
            Troop_Name = Troop_Name_;
            Troop_Resource1_Cost = Troop_Resource1_Cost_;
            Troop_HitPoints = Troop_HitPoints_;
            Troop_HitPoints_Remaining = Troop_HitPoints_;
            Troop_Food_Consumption = Troop_Food_Consumption_;
            Troop_Damage = Troop_Damage_;
            Troop_NumberOfAttacks = Troop_NumberOfAttacks_;
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
            string Enemy_Name_,
            int Enemy_HitPoints_,
            int Enemy_Damage_,
            int Enemy_NumberOfAttacks_,
            int Enemy_CreationCost_
            )
        {
            ID = Guid.NewGuid();
            Enemy_Name = Enemy_Name_;
            Enemy_HitPoints = Enemy_HitPoints_;
            Enemy_HitPoints_Remaining = Enemy_HitPoints_;
            Enemy_Damage = Enemy_Damage_;
            Enemy_NumberOfAttacks = Enemy_NumberOfAttacks_; 
            Enemy_CreationCost = Enemy_CreationCost_;
        }
    }
    internal class Enemy_Basic1 : Game_Enemies
    {
        public Enemy_Basic1() : base(
            (string)BaseDeDatos.Enemies[0][0],  // Enemy_Name
            (int)BaseDeDatos.Enemies[0][1],     // Enemy_HitPoints
            (int)BaseDeDatos.Enemies[0][2],     // Enemy_Damage
            (int)BaseDeDatos.Enemies[0][3],     // Enemy_NumberOfAttacks
            (int)BaseDeDatos.Enemies[0][4]      // Enemy_CreationCost
        ) { }
    }
    internal class Enemy_Advanced1 : Game_Enemies
    { public Enemy_Advanced1() : base(
            (string)BaseDeDatos.Enemies[1][0],  // Enemy_Name
            (int)BaseDeDatos.Enemies[1][1],     // Enemy_HitPoints
            (int)BaseDeDatos.Enemies[1][2],     // Enemy_Damage
            (int)BaseDeDatos.Enemies[1][3],     // Enemy_NumberOfAttacks
            (int)BaseDeDatos.Enemies[1][4]      // Enemy_CreationCost
        ) { } }
}
