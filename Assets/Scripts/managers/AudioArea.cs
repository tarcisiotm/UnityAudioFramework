using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityAudioFramework
{
	public class AudioArea : MonoBehaviour { //TODO think about this name if it properly portrays what it is supposed to do

		public float m_masterVolume = 1;

		public int SceneBuildIndex {get{ return m_sceneBuildIndex;}}
		int m_sceneBuildIndex;

		public List<AudioEvent> m_audioEvents = null;

		public enum TransitionType
		{
			none = 0,
			fadeOnSceneChange = 1,
			fadeBeforeSceneChange = 2,
		}

		public TransitionType m_transitionType = TransitionType.fadeBeforeSceneChange;

		void Start()
		{
			m_sceneBuildIndex = SceneManager.GetActiveScene ().buildIndex;
		}

		void OnEnable()
		{
			AudioManager.Instance.AddArea (this);
		}

		void OnDisable()
		{
			AudioManager.Instance.RemoveArea (this);
		}

		void SetDontDestroyOnLoad()
		{
			transform.SetParent (null);
			DontDestroyOnLoad (this);
		}

		void FadeOutAudio()
		{
			foreach (AudioEvent audioEvent in m_audioEvents)
			{
				audioEvent.FadeOut (AudioManager.Instance.m_sceneFadeTime);
			}
		}

		public void HandleSceneToChange()
		{
			SetDontDestroyOnLoad ();
			FadeOutAudio ();
		}

		#region Destroy

		public void DestroyAreaOnEndOfFrame()
		{
			SetDontDestroyOnLoad ();
			StartCoroutine (Internal_DestroyArea ());
		}

		IEnumerator Internal_DestroyArea()
		{
			yield return new WaitForEndOfFrame ();
			DestroyArea ();
		}


		void DestroyArea()
		{
			AudioManager.Instance.RemoveArea (this);
			Destroy (this);
		}

		#endregion

	}
}
