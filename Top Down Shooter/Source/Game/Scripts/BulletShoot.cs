using System;
using System.Collections.Generic;
using FlaxEngine;

namespace Game
{
	public class BulletShoot : Script
	{
		[Serialize] [ShowInEditor] Prefab Bullet;
		[Serialize] [ShowInEditor] float ShootCoolDown = 0.2f;

		private float currentCoolDown = 0f;
		
		public override void OnUpdate()
		{
			currentCoolDown -= Time.DeltaTime;

			if (Input.GetAction("Fire") && currentCoolDown <= 0)
			{
				currentCoolDown = ShootCoolDown;
				Actor bullet = PrefabManager.SpawnPrefab(Bullet, Actor.Position, Actor.Orientation);

				Ray ray = Camera.MainCamera.ConvertMouseToRay(Input.MousePosition);
				if (Physics.RayCast(ray.Position, ray.Direction, out RayCastHit hit))
				{
					hit.Point.Y = 50;

					bullet.LookAt(hit.Point);

				}
			}
		}
	}
}
