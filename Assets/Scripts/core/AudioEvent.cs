using UnityEngine;
using System;
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

		public enum PlaybackState
		{
			BEFORE_INIT,
			PLAYING,
			PAUSED,
			STOPPED,
			DONE_PLAYING
		}

		protected bool IsPlaying { get { return m_AudioSource.isPlaying;}}

		PlaybackState m_PlaybackState;
		public PlaybackState PlaybackStateAudio {get{ return m_PlaybackState;}}

		#region Initialization

		public virtual void Awake()
		{
		}


		public virtual void Init(AudioClip p_audioClip, AudioSettings p_audioSettings)
		{
			p_audioSettings.clip = p_audioClip;
			Setup (p_audioSettings);
		}

		public void OnEnable()
		{
			//reset settings in case of Pooling system
		}

		public void Setup(AudioSettings settings = null)
		{
			if (settings == null)
			{
				settings = AudioSettingsTemplates.GetDefaultSettings ();
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
			SetPlaybackState (PlaybackState.BEFORE_INIT);
			m_AudioSource.time = 0;
		}

		#region Playback

		protected void SetPlaybackState(PlaybackState playbackState)
		{
			m_PlaybackState = playbackState;
		}

		public void PlayFromStart()
		{
			ResetPlayback ();
			Play ();
		}

		public virtual void Play()
		{
			SetPlaybackState (PlaybackState.PLAYING);
			m_AudioSource.Play ();
			PlayAction (m_Settings.OnStartedPlaying);
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
			SetPlaybackState (PlaybackState.PAUSED);
		}

		public void UnPause()
		{
			m_AudioSource.UnPause ();
			SetPlaybackState (PlaybackState.PLAYING);
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

		/*IEnumerator Internal_Play()
		{
			while (m_PlaybackState == PlaybackState.PLAYING)
			{
				yield return new WaitForEndOfFrame ();
			}
		}*/

		#endregion Coroutines
		// Update is called once per frame
		void Update () {
		
		}

		#region Util

		/// <summary>
		/// Plays the method checking for null.
		/// </summary>
		/// <param name="p_Action">The method to be called.</param>
		protected void PlayAction(Action p_Action)
		{
			if (p_Action != null)
			{
				p_Action ();
			}
		}

		#endregion Util

		#region CleanUp

		void OnDisable()
		{
			Debug.Log ("Calling OnDisable on: " + gameObject.name);
			m_Settings = null;
			SetPlaybackState (PlaybackState.BEFORE_INIT);
		}

		protected void DestroyAudioObject()
		{
			Destroy (this.gameObject);
		}

		#endregion Cleanup
	}
}
