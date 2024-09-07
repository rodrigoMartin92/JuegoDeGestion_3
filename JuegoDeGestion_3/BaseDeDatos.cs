public class BaseDeDatos
{
    // Lista de Edificios
    public static List<List<object>> Buildings = new List<List<object>>();

    // Función para agregar Edificios
    public static void AgregarBuilding(
        string Building_Name,
        int Building_HitPoints,
        int Building_Resource1_Cost
        )
    {
        List<object> edificio = new List<object> {
            Building_Name,
            Building_HitPoints,
            Building_Resource1_Cost
        };
        Buildings.Add(edificio);
    }

    public static void AgregarBuildings()
    {
        // Agregar algunos Edificios
        AgregarBuilding("Main Fortress", 1000, 200);
        AgregarBuilding("Wood Gathering", 500, 100);
    }

    // Lista de Tropas
    public static List<List<object>> Troops = new List<List<object>>();

    // Función para agregar Tropas
    public static void AgregarTroop(
        string Troop_Name,
        int Troop_HitPoints,
        int Troop_Damage,
        int Troop_NumberOfAttacks,
        int Troop_Resource1_Cost,
        int Food_Consumption)
    {
        List<object> tropa = new List<object> {
            Troop_Name,
            Troop_HitPoints,
            Troop_Damage,
            Troop_NumberOfAttacks,
            Troop_Resource1_Cost,
            Food_Consumption
        };
        Troops.Add(tropa);
    }

    public static void AgregarTroops()
    {
        // Agregar algunas Tropas
        AgregarTroop("Basic troop", 150, 10, 2, 50, 10);
        AgregarTroop("Advanced troop", 250, 20, 3, 100, 30);
    }

    // Lista de Enemigos
    public static List<List<object>> Enemies = new List<List<object>>();

    // Función para agregar Enemigos
    public static void AgregarEnemy(
        string Enemy_Name,
        int Enemy_HitPoints,
        int Enemy_Damage,
        int Enemy_NumberOfAttacks,
        int Enemy_CreationCost)
    {
        List<object> enemigo = new List<object> {
            Enemy_Name,
            Enemy_HitPoints,
            Enemy_Damage,
            Enemy_NumberOfAttacks,
            Enemy_CreationCost
        };
        Enemies.Add(enemigo);
    }

    public static void AgregarEnemys()
    {
        // Agregar algunos Enemigos
        AgregarEnemy("Basic Enemy", 150, 5, 1, 10);
        AgregarEnemy("Advanced Enemy", 250, 15, 2, 30);
    }
}
