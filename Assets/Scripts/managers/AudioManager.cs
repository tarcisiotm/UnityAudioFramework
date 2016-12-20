using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityAudioFramework
{
	public class AudioManager : Singleton<AudioManager> {

		List<AudioArea> m_audioAreas = null;

		public bool CanUnloadScene {get { return m_canUnloadScene;}}

		bool m_canUnloadScene = false;
		//bool m_unloadingScene = false;

		[Tooltip("Time to let the audio areas unload before letting the new scene load completely.")]
		public float m_sceneFadeTime = 1f;

		public override void Awake()
		{
			base.Awake ();
			SceneManager.activeSceneChanged += OnSceneChanged;
			m_audioAreas = new List<AudioArea> ();
		}

		//Set the action that must follow being able to change scenes 
		Action OnSceneUnloaded = null;

		// Use this for initialization
		void Start ()
		{
			//AudioLoop audioLoop = AudioFactory.InstantiateAudioLoop (null, null);
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		#region Area Handling

		public void AddArea(AudioArea p_audioArea)
		{
			m_audioAreas.Add (p_audioArea);
		}

		public void RemoveArea(AudioArea p_audioArea)
		{
			m_audioAreas.Remove (p_audioArea);
		}

		#endregion Area Handling


		#region SceneManagement

		void OnSceneChanged(Scene p_previousScene, Scene p_newScene)
		{
			 
		}

		void UnloadAreasFromScene(int p_sceneBuildIndexToUnload)
		{
			m_canUnloadScene = true;

			List<AudioArea> areasToHandle = new List<AudioArea> ();

			foreach (AudioArea audioArea in m_audioAreas)
			{
				if (p_sceneBuildIndexToUnload == audioArea.SceneBuildIndex)
				{
					areasToHandle.Add (audioArea);
				}
			}

			if (areasToHandle.Count > 0)
			{
				UnloadAreas (areasToHandle);
			}
		
		}

		void UnloadAreas(List<AudioArea> p_audioAreas)
		{
			bool waitForUnload = false;

			foreach (AudioArea audioArea in p_audioAreas)
			{
				switch (audioArea.m_transitionType)
				{
					case AudioArea.TransitionType.none:
						audioArea.DestroyAreaOnEndOfFrame ();
						break;
					case AudioArea.TransitionType.fadeBeforeSceneChange:
						audioArea.HandleSceneToChange ();
						break;
					case AudioArea.TransitionType.fadeOnSceneChange:
						audioArea.HandleSceneToChange ();
						waitForUnload = true;
						break;
				}
			}

			if (waitForUnload)
			{
				Internal_WaitForUnload ();
			}
			else
			{
				OnUnloadedAreas ();
			}
		}


			
		IEnumerator Internal_WaitForUnload()
		{
			yield return new WaitForSeconds (m_sceneFadeTime);
			OnUnloadedAreas ();
		}

		void OnUnloadedAreas()
		{
			if (OnSceneUnloaded != null)
			{
				OnSceneUnloaded (); //this ideally will be hooked up to some scene management system which will get at least audio's "go ahead" to finish the transition to a new scene
			}
		}

		List<int> ScenesLoaded(){
			List<int> sceneList = new List<int> ();

			if (SceneManager.sceneCount > 0)
			{
				for (int n = 0; n < SceneManager.sceneCount; ++n)
				{
					sceneList.Add(SceneManager.GetSceneAt (n).buildIndex);
				}
			}

			return sceneList;
		}

		#endregion SceneManagement


	}
}
