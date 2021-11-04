using System;
using System.Collections.Generic;
using FlaxEngine;

namespace Game
{
    public class PlayerController : Script
    {
        [Serialize] [ShowInEditor] float Speed = 150f;

        public override void OnStart()
        {
            // Here you can add code that needs to be called when script is created, just before the first game update
        }

        public override void OnUpdate()
        {
            MovePlayer();
        }

        private void MovePlayer()
        {
            Vector3 inputVector = GetInput();

            Actor.As<CharacterController>().Move(inputVector * Speed * Time.DeltaTime);

            
        }

        private Vector3 GetInput()
        {
            return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).Normalized;
        }
    }
}
