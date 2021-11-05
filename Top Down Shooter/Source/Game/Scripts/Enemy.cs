using System;
using System.Collections.Generic;
using FlaxEngine;

namespace Game
{
    public class Enemy : Script
    {
        [Serialize] [ShowInEditor] float Speed = 200f;

        Actor player;

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
            Actor.LookAt(player.Position);
            Actor.As<CharacterController>().Move(Transform.Forward * Speed * Time.DeltaTime);
        }

        private void OnTriggerEnter(PhysicsColliderActor other)
        {
            if (other.HasTag("Bullet"))
			{
                Destroy(other);
                Destroy(Actor);
            }
            else if (other.HasTag("Player"))
			{
                Debug.Log("Game Over!");
            }
        }
    }
}
