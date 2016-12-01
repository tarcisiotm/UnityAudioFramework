using UnityEngine;
using System.Collections;

namespace UnityAudioFramework
{
	[RequireComponent(typeof(AudioSource))]
	public abstract class AudioEvent : MonoBehaviour {

		[SerializeField]
		public AudioSettings m_Settings;

		Coroutine Coroutine_Playback;

		AudioSource audioSource;
		public AudioSource m_AudioSource
		{ get
			{
				if (audioSource == null)
				{
					audioSource = GetComponent<AudioSource> ();
				}
				return audioSource;
			}
		}

		enum PlaybackState
		{
			BEFORE_INIT,
			PLAYING,
			PAUSED,
			STOPPED,
			DONE_PLAYING
		}

		PlaybackState m_PlaybackState;

		#region Initialization

		public virtual void Awake()
		{
			
		}

		public virtual void Init()
		{
			
		}

		public void OnEnable()
		{
			//reset settings in case of Polling system
		}

		public void Setup(AudioSettings settings)
		{
			if (settings == null)
			{
				//TODO Load default settings
			}

			m_Settings = settings;

			m_AudioSource.clip = settings.clip;
			m_AudioSource.outputAudioMixerGroup = settings.outputAudioMixerGroup;
			m_AudioSource.playOnAwake = settings.playOnAwake;
			m_AudioSource.loop = settings.loop;
			m_AudioSource.volume = settings.volume;
			m_AudioSource.pitch = settings.pitch;
			m_AudioSource.panStereo = settings.panStereo;
			m_AudioSource.spatialBlend = settings.spatialBlend;
		}

		// Use this for initialization
		void Start () {
		
		}

		#endregion Initialization

		void ResetPlayback()
		{
			m_PlaybackState = PlaybackState.BEFORE_INIT;
			m_AudioSource.time = 0;
		}

		#region Playback

		public void PlayFromStart()
		{
			ResetPlayback ();
			Play ();
		}

		public void Play()
		{
			m_PlaybackState = PlaybackState.PLAYING;
			m_AudioSource.Play ();
			//TODO COROUTINE TO HANDLE PLAYBACK
		}

		public void Stop()
		{
			ResetPlayback ();
			m_AudioSource.Pause ();
		}

		public void Pause()
		{
			m_AudioSource.Pause ();
			m_PlaybackState = PlaybackState.PAUSED;
		}

		public void UnPause()
		{
			m_AudioSource.UnPause ();
			m_PlaybackState = PlaybackState.PLAYING;
		}

		public void TogglePause()
		{
			if (m_PlaybackState == PlaybackState.PAUSED)
			{
				UnPause ();
			}
			else
			{
				Pause ();
			}
		}

		#endregion Playback

		#region Playback_Fade



		#endregion Playback_Fade


		#region Coroutines

		IEnumerator Internal_Play()
		{
			while (m_PlaybackState == PlaybackState.PLAYING)
			{
				yield return new WaitForEndOfFrame ();
			}
		}

		#endregion Coroutines
		// Update is called once per frame
		void Update () {
		
		}

		#region CleanUp

		void OnDisable()
		{
			Debug.Log ("Calling OnDisable on: " + gameObject.name);
			m_Settings = null;
			m_PlaybackState = PlaybackState.BEFORE_INIT;
		}

		void DestroyAudioObject()
		{
			
		}

		#endregion Cleanup
	}
}
