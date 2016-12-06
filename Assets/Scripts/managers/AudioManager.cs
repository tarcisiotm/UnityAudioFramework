using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityAudioFramework
{
	public class AudioManager : Singleton<AudioManager> {

		Dictionary<Scene, AudioArea> m_audioAreaSceneDic; //TODO check to see whether we should use a dictionary or normal audio areas and add the scene info to all the areas

		List<AudioArea> m_audioAreas;

		public override void Awake()
		{
			SceneManager.activeSceneChanged += OnSceneChanged;
		}

		// Use this for initialization
		void Start () {
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		#region Area Handling

		public void AddArea(AudioArea p_audioArea)
		{
		}

		#endregion Area Handling

		#region SceneManagement

		void OnSceneChanged(Scene p_previousScene, Scene p_newScene)
		{
			
		}

		#endregion SceneManagement


	}
}
