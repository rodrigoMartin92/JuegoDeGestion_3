using System;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace JuegoDeGestion_3
{
    public partial class Interfaz_Grafica : Form
    {
        public int Turns = 0; public int Flag_GameDifficult = 1; public int Resource1_Amount = 1000;
        internal List<Game_Building> createdBuildings = new List<Game_Building>();
        internal List<Game_Troops> createdTroops = new List<Game_Troops>();
        private List<Game_Enemies> createdEnemies = new List<Game_Enemies>();
        public int Enemy_AttackForce = 0; public int Enemy_AttackForce_Remaining = 0;
        public enum Game_Categories { Buildings, Troops }
        public enum Game_Difficulty { Dificult_1, Dificult_2 }
        public enum Game_Building_Category { Building_Main_Fortress, Building_Resource1Gathering }
        public enum Game_Troops_Category { Troop_Basic1, Troop_Advanced1 }
        public enum Game_EnemyType { Enemy_Basic1, Enemy_Advanced1 }
        // ------------------------------------------------ ACTUALIZACION DE DATOS ------------------------------------------------
        // ------------------------------------------------ ACTUALIZACION DE UI ------------------------------------------------
        public Interfaz_Grafica()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(Enum.GetNames(typeof(Game_Categories)));
            comboBox1.SelectedIndex = 0;
            comboBox2.Items.AddRange(Enum.GetNames(typeof(Game_Difficulty)));
            comboBox2.SelectedIndex = 0;
            listBox1.Items.Add("Resource1 = " + Resource1_Amount);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                listBox2.Items.Clear();
                string selectedCategory = comboBox1.SelectedItem.ToString();
                if (selectedCategory == "Buildings")
                { listBox2.Items.AddRange(Enum.GetNames(typeof(Game_Building_Category))); }
                else if (selectedCategory == "Troops")
                { listBox2.Items.AddRange(Enum.GetNames(typeof(Game_Troops_Category))); }
            }
            catch (Exception ex)
            {                MessageBox.Show(ex.ToString());            }
        }
        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                listBox6.Items.Clear();
                if (listBox3.SelectedItem != null)
                {
                    string selectedBuildingType = listBox3.SelectedItem.ToString();
                    Game_Building selectedBuilding = createdBuildings.FirstOrDefault(b => b.GetType().Name == selectedBuildingType);
                    if (selectedBuilding != null)
                    {
                        listBox6.Items.Add($"ID: {selectedBuilding.ID}");
                        listBox6.Items.Add($"Name: {selectedBuilding.Building_Name}");
                        listBox6.Items.Add($"Hit Points: {selectedBuilding.Building_HitPoints}");
                        listBox6.Items.Add($"Remaining Hit Points: {selectedBuilding.Building_HitPoints_Remaining}");
                        listBox6.Items.Add($"Quality: {selectedBuilding.Building_Quality}");
                        listBox6.Items.Add($"Building resource1 cost: {selectedBuilding.Building_Resource1_Cost}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                listBox6.Items.Clear();
                if (listBox5.SelectedItem != null)
                {
                    Game_Enemies selectedEnemy = (Game_Enemies)listBox5.SelectedItem;
                    if (selectedEnemy != null)
                    {
                        listBox6.Items.Add($"ID: {selectedEnemy.ID}");
                        listBox6.Items.Add($"Nombre: {selectedEnemy.Enemy_Name}");
                        listBox6.Items.Add($"Puntos de vida: {selectedEnemy.Enemy_HitPoints}");
                        listBox6.Items.Add($"Puntos de vida restantes: {selectedEnemy.Enemy_HitPoints_Remaining}");
                        listBox6.Items.Add($"Daño: {selectedEnemy.Enemy_Damage}");
                        listBox6.Items.Add($"Número de ataques: {selectedEnemy.Enemy_NumberOfAttacks}");
                        listBox6.Items.Add($"Costo de creación: {selectedEnemy.Enemy_CreationCost}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox6.Items.Clear();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Player_Attack(ref listBox5);
            Enemies_Attack_Player(ref listBox4);
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() == "Dificult_1")
            { Flag_GameDifficult = 1; }
            else if (comboBox2.SelectedItem.ToString() == "Dificult_2")
            { Flag_GameDifficult = 2; }
        }
        // ------------------------------------------------ BOTONES ------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            // Create buildings or tropps
            try
            {
                if (listBox2.SelectedItem != null)
                {
                    listBox3.Items.Clear();
                    string Selected_Element = listBox2.SelectedItem.ToString();
                    Create_Building_Troop(Selected_Element, ref listBox1, ref listBox4, ref Resource1_Amount);
                }

            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Next turn
                int FuerzaDeAtaque = Next_Turn(Flag_GameDifficult, ref Turns, listBox1, ref listBox5, ref Enemy_AttackForce, ref Enemy_AttackForce_Remaining, ref Resource1_Amount);
                textBox1.Text = "Turno = " + Turns.ToString() + " - FuerzaDeAtaque = " + FuerzaDeAtaque.ToString();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }

        }
        private void button4_Click(object sender, EventArgs e) { }
        private void button5_Click(object sender, EventArgs e) { }
        // ------------------------------------------------ FUNCIONES ------------------------------------------------
        // Métodos para contar instancias de edificios y tropas creadas
        public (Dictionary<string, int> buildingCounts, Dictionary<string, int> troopCounts) CountInstancesData()
        {
            var buildingCounts = new Dictionary<string, int>();
            var troopCounts = new Dictionary<string, int>();
            foreach (var building in createdBuildings)
            {
                string buildingType = building.GetType().Name;
                if (buildingCounts.ContainsKey(buildingType))
                {
                    buildingCounts[buildingType]++;
                }
                else
                {
                    buildingCounts[buildingType] = 1;
                }
            }
            foreach (var troop in createdTroops)
            {
                string troopType = troop.GetType().Name;
                if (troopCounts.ContainsKey(troopType))
                {
                    troopCounts[troopType]++;
                }
                else
                {
                    troopCounts[troopType] = 1;
                }
            }
            return (buildingCounts, troopCounts);
        }
        // Método que avanza al siguiente turno
        public int Next_Turn(int Dificultad, ref int Turnos, ListBox listBox, ref ListBox listBox2, ref int Enemy_AttackForce, ref int Enemy_AttackForce_Remaining, ref int Resource1_Amount)
        {
            try
            {
                Turnos++; // Incrementar el número de turnos
                int FuerzaDeAtaque;
                Add_Resources(listBox, ref Resource1_Amount); // Agregar recursos
                // Aumentar la fuerza de los enemigos según la dificultad
                switch (Dificultad)
                {
                    case 1:
                        Increase_EnemyStrength(Game_Difficulty.Dificult_1, ref Enemy_AttackForce, ref Enemy_AttackForce_Remaining);
                        break;
                    case 2:
                        Increase_EnemyStrength(Game_Difficulty.Dificult_2, ref Enemy_AttackForce, ref Enemy_AttackForce_Remaining);
                        break;
                    default:
                        throw new ArgumentException("Dificultad no válida");
                }
                FuerzaDeAtaque = Enemy_AttackForce;
                List<int> Enemies_RandomNumbers = GenerateEnemies_RandomNumbers(1, 2, 30); // Generar números aleatorios para enemigos
                Enemy_RandomGeneration(Enemies_RandomNumbers, Enemy_AttackForce, out createdEnemies, listBox2, ref listBox5, ref Enemy_AttackForce_Remaining); // Generar enemigos aleatoriamente
                return FuerzaDeAtaque;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()); // Mostrar mensaje de error si algo sale mal
                return -1; // Retornar un valor por defecto en caso de error
            }
        }
        // Método para aumentar la fuerza de los enemigos según la dificultad
        public void Increase_EnemyStrength(Game_Difficulty difficulty, ref int Enemy_AttackForce, ref int Enemy_AttackForce_Remaining)
        {
            switch (difficulty)
            {
                case Game_Difficulty.Dificult_1:
                    Enemy_AttackForce += (Enemy_AttackForce + 100);
                    Enemy_AttackForce_Remaining = Enemy_AttackForce;
                    break;
                case Game_Difficulty.Dificult_2:
                    Enemy_AttackForce += (Enemy_AttackForce + 10) + (Enemy_AttackForce * 2);
                    Enemy_AttackForce_Remaining = Enemy_AttackForce;
                    break;
                default:
                    // Código para caso por defecto (no definido)
                    break;
            }
        }
        // Método para agregar recursos al jugador basados en los edificios construidos
        public void Add_Resources(ListBox listBox, ref int Resource1_Amount)
        {
            try
            {
                // Contar la cantidad de instancias de "Building_Resource1Gathering"
                int resource1GatheringCount = createdBuildings.Count(building => building is Building_Resource1Gathering);
                // Agregar 200 unidades por cada instancia de Building_Resource1Gathering
                Resource1_Amount += resource1GatheringCount * 200;
                // Actualizar la interfaz con la nueva cantidad de Resource1
                listBox.Items.Clear();
                listBox.Items.Add("Resource1 = " + Resource1_Amount);
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
        // Método para crear edificios o tropas
        public void Create_Building_Troop(string Building_Troop, ref ListBox listBox1, ref ListBox listBox2, ref int Resource1_Amount)
        {
            try
            {
                // Diccionario que mapea el nombre del edificio/tropa con una función que crea una instancia de ese tipo
                var creationMap = new Dictionary<string, Func<object>>()
        {
            { "Building_Main_Fortress", () => new Building_Main_Fortress() },
            { "Building_Resource1Gathering", () => new Building_Resource1Gathering() },
            { "Troop_Basic1", () => new Troop_Basic1() },
            { "Troop_Advanced1", () => new Troop_Advanced1() }
        };
                if (creationMap.ContainsKey(Building_Troop))
                {
                    var instance = creationMap[Building_Troop]();
                    int cost = 0;
                    // Si la instancia es un edificio
                    if (instance is Game_Building building)
                    {
                        cost = building.Building_Resource1_Cost;
                        createdBuildings.Add(building);
                    }
                    // Si la instancia es una tropa
                    else if (instance is Game_Troops troop)
                    {
                        cost = troop.Troop_Resource1_Cost;
                        createdTroops.Add(troop);

                        // Agregar la tropa creada individualmente a la listBox4
                        listBox2.Items.Add(troop);
                    }
                    // Restar el costo de producción de Resource1_Amount
                    if (Resource1_Amount >= cost)
                    {
                        Resource1_Amount -= cost;
                    }
                    else
                    {
                        MessageBox.Show("No tienes suficientes recursos para crear este elemento.");
                        return;
                    }
                    // Actualizar la listBox1 con la nueva cantidad de Resource1
                    listBox1.Items.Clear();
                    listBox1.Items.Add("Resource1 = " + Resource1_Amount);
                }
                else
                {
                    MessageBox.Show("Error in 'Create_Building_Troop'"); // Mostrar mensaje si no se encuentra el elemento
                }
                // Llamar a la función para contar las instancias creadas
                CountInstances();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }


        // Método para generar una lista de números aleatorios dentro de un rango específico
        public static List<int> GenerateEnemies_RandomNumbers(int Min_Number, int Max_number, int NumberOfNumbers)
        {
            Random random = new Random();
            List<int> randomNumbers = new List<int>();
            for (int i = 0; i < NumberOfNumbers; i++)
            {
                int number = random.Next(Min_Number, Max_number + 1);
                randomNumbers.Add(number);
            }
            return randomNumbers;
        }
        // Método para crear enemigos basados en el tipo especificado
        public Game_Enemies? Create_Enemy(string Enemy_Type, ref ListBox listBox)
        {
            try
            {
                // Diccionario que mapea el nombre del enemigo con una función que crea una instancia de ese enemigo
                var creationMap = new Dictionary<string, Func<Game_Enemies>>()
                {
                    { "Enemy_Basic1", () => new Enemy_Basic1() },
                    { "Enemy_Advanced1", () => new Enemy_Advanced1() }
                };
                if (creationMap.ContainsKey(Enemy_Type))
                {
                    // Crear la instancia del enemigo correspondiente
                    var enemyCreated = creationMap[Enemy_Type]();
                    // Añadir información del enemigo creado a listBox5
                    listBox.Items.Add(enemyCreated);
                    return enemyCreated;
                }
                else
                {
                    MessageBox.Show("Enemy type not found in 'Create_Enemy'"); // Mostrar mensaje si el tipo de enemigo no se encuentra
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            return null;
        }
        // Método para crear un enemigo basado en un número dado
        public Game_Enemies? Enemy_Creation(int Enemy_Number, ref ListBox listBox5)
        {
            switch (Enemy_Number)
            {
                case 1:
                    return Create_Enemy("Enemy_Basic1", ref listBox5);
                case 2:
                    return Create_Enemy("Enemy_Advanced1", ref listBox5);
                default:
                    MessageBox.Show("Invalid enemy number in 'Enemy_Creation'");
                    return null;
            }
        }
        // Método para generar enemigos aleatoriamente hasta que la fuerza restante sea menor a 10
        public void Enemy_RandomGeneration(List<int> list_RandomNumbers, int enemy_AttackForce_Remaining, out List<Game_Enemies> createdEnemies, ListBox listBox, ref ListBox listBox2, ref int Enemy_AttackForce_Remaining)
        {
            createdEnemies = new List<Game_Enemies>(); // Inicializar 'createdEnemies' al inicio para evitar el error
            try
            {
                listBox2.Items.Clear();
                int enemy_AttackForce_Remaining_Function = enemy_AttackForce_Remaining;

                foreach (int randomNumber in list_RandomNumbers)
                {
                    if (enemy_AttackForce_Remaining_Function < 10)
                    {
                        break; // Detener generación de enemigos si el ataque restante es menor a 10.
                    }

                    Game_Enemies? enemyCreated = null;
                    if (enemy_AttackForce_Remaining_Function >= 10 && enemy_AttackForce_Remaining_Function < 30)
                    {
                        enemyCreated = Create_Enemy("Enemy_Basic1", ref listBox);
                        enemy_AttackForce_Remaining_Function -= 10;
                    }
                    else
                    {
                        enemyCreated = Enemy_Creation(randomNumber, ref listBox2);
                        if (enemyCreated != null)
                        {
                            enemy_AttackForce_Remaining_Function -= enemyCreated.Enemy_CreationCost;
                        }
                    }

                    if (enemyCreated != null)
                    {
                        createdEnemies.Add(enemyCreated);
                    }
                }
                Enemy_AttackForce_Remaining = enemy_AttackForce_Remaining_Function;
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
        public void CountInstances()
        {
            try
            {
                var (buildingCounts, troopCounts) = CountInstancesData();
                UpdateInterfaceWithCounts(buildingCounts, troopCounts, ref listBox1, ref listBox3, ref listBox4);
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
        public void UpdateInterfaceWithCounts(Dictionary<string, int> buildingCounts, Dictionary<string, int> troopCounts, ref ListBox listBox1, ref ListBox listBox3, ref ListBox listBox4)
        {
            try
            {
                listBox1.Items.Clear();
                listBox3.Items.Clear();
                listBox4.Items.Clear();
                listBox1.Items.Add("Resource1 = " + Resource1_Amount);
                foreach (var count in buildingCounts)
                {
                    for (int i = 0; i < count.Value; i++)
                    {
                        listBox3.Items.Add($"{count.Key}");
                    }
                }
                foreach (var count in troopCounts)
                {
                    listBox4.Items.Add($"{count.Value} x {count.Key}");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
        // Método para que una tropa ataque a un enemigo
        public void Troop_Attack(Game_Troops attackingTroop, ref ListBox listBox5)
        {
            string Lista_Revision;
            try
            {
                if (createdEnemies.Count > 0)
                {
                    Random random = new Random();
                    int index = random.Next(createdEnemies.Count);
                    Game_Enemies targetedEnemy = createdEnemies[index];

                    targetedEnemy.Enemy_HitPoints_Remaining -= attackingTroop.Troop_Damage;

                    Lista_Revision = attackingTroop.Troop_Damage.ToString();

                    if (targetedEnemy.Enemy_HitPoints_Remaining <= 0)
                    {
                        createdEnemies.Remove(targetedEnemy);
                        listBox5.Items.Remove(targetedEnemy);

                        // Actualiza la interfaz para reflejar la eliminación del enemigo
                        listBox5.Items.Clear();
                        foreach (var enemy in createdEnemies)
                        {
                            listBox5.Items.Add(enemy);
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
        public void Full_Troop_Attack(Game_Troops attackingTroop, ref ListBox listBox5)
        {
            List<string> Lista_Revision_F2 = new List<string>();
            try
            {
                if (createdEnemies.Count == 0)
                {
                    return;
                }
                int NumberOfTroopAttacks = attackingTroop.Troop_NumberOfAttacks;
                for (int i = 0; i < NumberOfTroopAttacks; i++)
                {
                    if (createdEnemies.Count == 0)
                    {
                        // Si no quedan enemigos, terminar los ataques restantes
                        break;
                    }
                    Troop_Attack(attackingTroop, ref listBox5);
                }
                // Actualizar la interfaz después de todos los ataques
                listBox5.Items.Clear();
                foreach (var enemy in createdEnemies)
                {
                    listBox5.Items.Add(enemy);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
        // Método para que todas las tropas del jugador ataquen
        public void Player_Attack(ref ListBox listBox5)
        {
            try
            {
                foreach (var troop in createdTroops)
                {
                    Full_Troop_Attack(troop, ref listBox5);
                }

                // Actualiza la interfaz después de que todas las tropas han atacado
                listBox5.Items.Clear();
                foreach (var enemy in createdEnemies)
                {
                    listBox5.Items.Add(enemy);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
        public void Full_Player_Attack()
        {
        }
        public void Enemy_Attack(Game_Enemies attackingEnemy, ref ListBox listBox4)
        {
            try
            {
                if (createdTroops.Count > 0)
                {
                    Random random = new Random();
                    int index = random.Next(createdTroops.Count);
                    Game_Troops targetedTroop = createdTroops[index];

                    targetedTroop.Troop_HitPoints_Remaining -= attackingEnemy.Enemy_Damage;

                    if (targetedTroop.Troop_HitPoints_Remaining <= 0)
                    {
                        createdTroops.Remove(targetedTroop);
                        listBox4.Items.Remove(targetedTroop);

                        // Actualiza la interfaz para reflejar la eliminación de la tropa
                        listBox4.Items.Clear();
                        foreach (var troop in createdTroops)
                        {
                            listBox4.Items.Add(troop);
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
        public void Full_Enemy_Attack(Game_Enemies attackingEnemy, ref ListBox listBox4)
        {
            try
            {
                if (createdTroops.Count == 0)
                {
                    return;
                }
                int numberOfEnemyAttacks = attackingEnemy.Enemy_NumberOfAttacks;
                for (int i = 0; i < numberOfEnemyAttacks; i++)
                {
                    if (createdTroops.Count == 0)
                    {
                        // Si no quedan tropas, terminar los ataques restantes
                        break;
                    }
                    Enemy_Attack(attackingEnemy, ref listBox4);
                }

                // Actualizar la interfaz después de todos los ataques
                listBox4.Items.Clear();
                foreach (var troop in createdTroops)
                {
                    listBox4.Items.Add(troop);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
        public void Enemies_Attack_Player(ref ListBox listBox4)
        {
            try
            {
                foreach (var enemy in createdEnemies)
                {
                    Full_Enemy_Attack(enemy, ref listBox4);
                }

                // Actualiza la interfaz después de que todos los enemigos han atacado
                listBox4.Items.Clear();
                foreach (var troop in createdTroops)
                {
                    listBox4.Items.Add(troop);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
    }
}
