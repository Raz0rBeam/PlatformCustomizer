using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlatformCustomizer.Miscellaneous
{
	// Based off of UITweaks' object grabber
	// https://github.com/Exomanz/UITweaks/blob/sira3/UITweaks/Utilities/SettingsPanelObjectGrabber.cs
	public class PlatformGrabber : MonoBehaviour
	{
		public bool completed = false;
		public static GameObject TemplatePlatform;

		public Action? CompletedEvent;

		public void Start()
		{
			StartCoroutine(GetPlatform());
		}

		private IEnumerator GetPlatform()
		{
			var sceneIsLoaded = false;
			try
			{
				if (completed)
				{
					Plugin.Log.Critical("sdifhioSHJERIOFHJ");
					yield break;
				}

				var loadScene = SceneManager.LoadSceneAsync("BigMirrorEnvironment", LoadSceneMode.Additive);
				yield return new WaitUntil(() => loadScene.isDone);

				sceneIsLoaded = true;
				yield return new WaitForSecondsRealtime(0.1f); // Allow objects to fully load

				foreach (var gamerObject in Resources.FindObjectsOfTypeAll<BloomFogEnvironment>())
				{
					if (gamerObject.name == "Environment")
					{
						TemplatePlatform = gamerObject.transform.Find("PlayersPlace").gameObject;

						break;
					}
				}
			}
			finally
			{
				if (sceneIsLoaded)
				{
					SceneManager.UnloadSceneAsync("BigMirrorEnvironment");
				}

				completed = true;
				CompletedEvent?.Invoke();
				Plugin.Log.Critical("sdifhioSHJERIOFHJ");
			}
		}
	}
}