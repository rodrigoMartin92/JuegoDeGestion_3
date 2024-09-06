using JuegoDeGestion_3;
using System;
using System.Collections.Generic;

public class BaseDeDatos
{
    // Lista de Unidades (cada Unidad es una lista que contiene el tipo, dimensiones y peso)
    public static List<List<object>> Buildings = new List<List<object>>();

    // Función para agregar Unidades
    public static void AgregarBuilding(
        string Building_Name,
        int Building_HitPoints,
        int Building_Resource1_Cost
        )
    {
        List<object> Unidad = new List<object> {
            Building_Name,
            Building_HitPoints,
            Building_Resource1_Cost};
        Troops.Add(Unidad);
    }
    public static void AgregarBuildings()
    {
        // Agregar algunos Unidades
        AgregarBuilding("Main Fortress", 1000, 200);
        AgregarBuilding("Wood Gathering", 500, 100);
    }

    // Lista de Unidades (cada Unidad es una lista que contiene el tipo, dimensiones y peso)
    public static List<List<object>> Troops = new List<List<object>>();

    // Función para agregar Unidades
    public static void AgregarTroop(
        string Troop_Name,
        int Troop_HitPoints,
        int Troop_Damage,
        int Troop_NumberOfAttacks,
        int Troop_Resource1_Cost,
        int Food_Consumption)
    {
        List<object> Unidad = new List<object> {
            Troop_Name,
            Troop_HitPoints,
            Troop_Damage,
            Troop_NumberOfAttacks,
            Troop_Resource1_Cost,
            Food_Consumption};
        Troops.Add(Unidad);
    }
    public static void AgregarTroops()
    {
        // Agregar algunos Unidades
        AgregarTroop("Basic troop", 150, 0, 10, 5, 10);
        AgregarTroop("Advanced troop", 250, 0, 20, 5, 30);
    }

    // Lista de Unidades (cada Unidad es una lista que contiene el tipo, dimensiones y peso)
    public static List<List<object>> Enemies = new List<List<object>>();

    // Función para agregar Unidades
    public static void AgregarEnemy(
        string Enemy_Name,
        int Enemy_HitPoints,
        int Enemy_Damage,
        int Enemy_NumberOfAttacks,
        int Enemy_CreationCost)
    {
        List<object> Unidad = new List<object> {
            Enemy_Name,
            Enemy_HitPoints,
            Enemy_Damage,
            Enemy_NumberOfAttacks,
            Enemy_CreationCost};
        Troops.Add(Unidad);
    }
    public static void AgregarEnemys()
    {
        // Agregar algunos Unidades
        AgregarEnemy("Basic Enemy", 150, 5, 20, 10);
        AgregarEnemy("Advanced Enemy", 250, 15, 20, 30);
    }
}
