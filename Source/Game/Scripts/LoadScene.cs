// © 2021 PecisionRender

using System;
using System.Collections.Generic;
using FlaxEngine;
using FlaxEngine.GUI;

namespace Game
{
    public class LoadScene : Script
    {
        [Serialize] [ShowInEditor] SceneReference NextScene;

		public override void OnEnable()
		{
			Actor.As<UIControl>().Get<Button>().Clicked += OnButtonClicked;
		}
		public override void OnDisable()
		{
			Actor.As<UIControl>().Get<Button>().Clicked -= OnButtonClicked;
		}

		private void OnButtonClicked()
		{
			Time.TimeScale = 1f;
			Level.ChangeSceneAsync(NextScene);
		}
	}
}
