// © 2021 PecisionRender

using System;
using System.Collections.Generic;
using FlaxEngine;

namespace Game
{
    public class SpawnManager : Script
    {
        [Serialize] [ShowInEditor] Prefab Enemy;

        private Actor spawnPoint;
        private float spawnCoolDown;
        private float enemyCoolDown = 4;
        private float enemyLerpRate = 0.01f;

        public override void OnStart()
        {
            spawnPoint = Actor.GetChild("SpawnPoint");
            RandomSpawnPosition();
        }

        public override void OnUpdate()
        {
            spawnCoolDown += Time.DeltaTime;
            enemyCoolDown = Mathf.Lerp(enemyCoolDown, 0, enemyLerpRate * Time.DeltaTime);

            if (spawnCoolDown >= enemyCoolDown)
			{
                spawnCoolDown = 0;
                PrefabManager.SpawnPrefab(Enemy, spawnPoint.Position);
                RandomSpawnPosition();
			}
        }

        private void RandomSpawnPosition()
		{
            Actor.LocalEulerAngles = new Vector3(0, new Random().Next(-180, 180), 0);
        }
    }
}
