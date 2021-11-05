// © 2021 PecisionRender

using System;
using System.Collections.Generic;
using FlaxEngine;
using FlaxEngine.GUI;

namespace Game
{
    public class PlayerController : Script
    {
        [Serialize] [ShowInEditor] float Speed = 150f;
        [Serialize] [ShowInEditor] UIControl ScoreUI;
        [Serialize] [ShowInEditor] UIControl GameOverUI;

        private int score = 0;
        private int highScore = 0;

        private Label scoreText;

		public override void OnStart()
		{
            scoreText = ScoreUI.GetChild("Score").As<UIControl>().Get<Label>();
            SetScoreText(0);
            
		}

		public override void OnUpdate()
        {
            MovePlayer();
            Boundry();
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

        private void Boundry()
		{
            if (Actor.Position.X > 550)
            {
                Actor.Position = new Vector3(550, Actor.Position.Y, Actor.Position.Z);
            }
            else if (Actor.Position.X < -550)
            {
                Actor.Position = new Vector3(-550, Actor.Position.Y, Actor.Position.Z);
            }

            if (Actor.Position.Z > 300)
            {
                Actor.Position = new Vector3(Actor.Position.X, Actor.Position.Y, 300);
            }
            else if (Actor.Position.Z < -300)
            {
                Actor.Position = new Vector3(Actor.Position.X, Actor.Position.Y, -300);
            }
        }

        public void EnemyDestroyed()
		{
            score += 1;
            SetScoreText(score);
        }

        private void SetScoreText(int newScore)
		{
            scoreText.Text = "Score: " + score.ToString();

		}

        public void GameOver()
		{
            GameOverUI.IsActive = true;
            Time.TimeScale = 0f;
		}
    }
}
