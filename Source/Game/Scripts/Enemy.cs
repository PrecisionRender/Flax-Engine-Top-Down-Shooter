// © 2021 PecisionRender

using System;
using System.Collections.Generic;
using FlaxEngine;

namespace Game
{
    public class Enemy : Script
    {
        [Serialize] [ShowInEditor] float Speed = 200f;

        private Actor player;
        private float lifetime = 0;

		public override void OnStart()
		{
            player = Scene.GetChild("Player");
        }

		public override void OnEnable()
        {
            Actor.As<CharacterController>().TriggerEnter += OnTriggerEnter;
        }

        public override void OnDisable()
        {
            Actor.As<CharacterController>().TriggerEnter -= OnTriggerEnter;
        }

        public override void OnUpdate()
        {
            lifetime += Time.DeltaTime;

            Actor.LookAt(player.Position);
            Actor.As<CharacterController>().Move(Transform.Forward * Speed * Time.DeltaTime);
        }

        private void OnTriggerEnter(PhysicsColliderActor other)
        {
            if (other.HasTag("Bullet") && lifetime >= 0.5f)
			{
                player.GetScript<PlayerController>().EnemyDestroyed();
                Destroy(other);
                Destroy(Actor);
            }
            else if (other.HasTag("Player") && lifetime >= 0.5f)
			{
                other.Parent.GetScript<PlayerController>().GameOver();
            }
        }
    }
}
