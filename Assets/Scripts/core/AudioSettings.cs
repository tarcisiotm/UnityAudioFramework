using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using System;

namespace UnityAudioFramework
{
	/// <summary>
	/// Settings for the audio to be played. Still deciding whether or not it is a good idea to isolate this from AudioEvent.
	/// </summary>
	[System.Serializable]
	public class AudioSettings {

		[Header("Options")]
		public Vector3 position = Vector3.zero;

		[Header("AudioSource Options")]
		public AudioClip clip = null;
		public AudioMixerGroup outputAudioMixerGroup = null;

		//bypass
		//bypass
		//bypass

		public bool playOnAwake = true;
		public bool loop = false;

		//priority

		[Tooltip("Initial Volume")]
		/// <summary>
		/// The initial volume. If fading in, this will be the final volume level.
		/// </summary>
		[Range(0f,1f)]
		public float volume = 1f;

		[Range(-3f,3f)]
		public float pitch = 1f;

		[Range(-1f,1f)]
		public float panStereo = 0f;

		[Range(0f,1f)]
		public float spatialBlend = 0f;

		[Header("Playback Options")]
		public bool fadeIn = false;
		public bool fadeOut = false;

		//reverbZoneMix

		[Header("Other Options")]

		public Action OnStartedPlaying = null;
		public Action OnFinishedPlaying = null; //ended up removing onscenechange in order to keep the core simpler. If needed be, use areas.
	}
}
