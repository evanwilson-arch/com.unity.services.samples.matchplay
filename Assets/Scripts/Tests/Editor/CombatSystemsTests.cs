using NUnit.Framework;
using UnityEngine;
using MilehighWorld.CombatSystems;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilehighWorld.Tests
{
    public class CombatSystemsTests
    {
        [Test]
        public void EncounterDirector_CanBeCreated()
        {
            var go = new GameObject("EncounterDirector");
            var director = go.AddComponent<EncounterDirector>();
            Assert.IsNotNull(director);
            Object.DestroyImmediate(go);
        }

        [Test]
        public void Characters_CanBeCreated()
        {
            var allyGo = new GameObject("Ally");
            var ally = allyGo.AddComponent<NovomindadCharacter>();
            Assert.IsNotNull(ally);

            var enemyGo = new GameObject("Enemy");
            var enemy = enemyGo.AddComponent<EnemyCharacter>();
            Assert.IsNotNull(enemy);

            Object.DestroyImmediate(allyGo);
            Object.DestroyImmediate(enemyGo);
        }
    }
}
