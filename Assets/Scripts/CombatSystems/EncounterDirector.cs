using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilehighWorld.CombatSystems
{
    /// <summary>
    /// Replaces the monolithic GeneratedScenario.cs to process data-driven events.
    /// </summary>
    public class EncounterDirector : MonoBehaviour
    {
        [Header("Encounter Timeline")]
        [SerializeField] private List<CombatEventSO> sequenceEvents;

        // Entity Registries
        private Dictionary<string, NovomindadCharacter> _novomindad = new Dictionary<string, NovomindadCharacter>();
        private Dictionary<string, EnemyCharacter> _enemies = new Dictionary<string, EnemyCharacter>();

        private async void Start()
        {
            InitializeEntities(); // Assumes dictionary population similar to previous iteration
            await ProcessEncounterAsync();
        }

        private void InitializeEntities()
        {
            // Placeholder for entity initialization
            // In a real scenario, this would find characters in the scene and register them
            var allies = FindObjectsByType<NovomindadCharacter>(FindObjectsSortMode.None);
            foreach (var ally in allies)
            {
                _novomindad[ally.name] = ally;
            }

            var enemies = FindObjectsByType<EnemyCharacter>(FindObjectsSortMode.None);
            foreach (var enemy in enemies)
            {
                _enemies[enemy.name] = enemy;
            }
        }

        private async Task ProcessEncounterAsync()
        {
            Debug.Log("<color=#E0BBE4>--- SCENARIO SEQUENCE COMMENCING ---</color>");

            foreach (var combatEvent in sequenceEvents)
            {
                if (combatEvent == null) continue;
                await combatEvent.ExecuteAsync(this);
            }

            Debug.Log("<color=#E0BBE4>--- SCENARIO SEQUENCE CONCLUDED ---</color>");
        }

        public NovomindadCharacter GetAlly(string id) => _novomindad.TryGetValue(id, out var character) ? character : null;
        public EnemyCharacter GetEnemy(string id) => _enemies.TryGetValue(id, out var enemy) ? enemy : null;
    }
}
