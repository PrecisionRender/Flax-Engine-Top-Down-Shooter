// © 2021 PecisionRender

using System;
using System.Collections.Generic;
using FlaxEngine;

namespace Game
{
    public class Bullet : Script
    {
        [Serialize] [ShowInEditor] float Speed = 1000;
        [Serialize] [ShowInEditor] float BullletLifetime = 2f;

        private float currentBulletLifetime;

		public override void OnStart()
		{
            currentBulletLifetime = BullletLifetime;
        }

        public override void OnUpdate()
        {
            currentBulletLifetime -= Time.DeltaTime;

            if (currentBulletLifetime <= 0)
			{
                Destroy(Actor);
			}

            Actor.Position += Transform.Forward * Speed * Time.DeltaTime;
        }
    }
}
