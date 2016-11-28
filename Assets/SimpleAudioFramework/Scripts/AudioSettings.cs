using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

namespace SimpleAudioFramework
{
	/// <summary>
	/// Settings for the audio to be played. Still deciding whether or not it is a good idea to isolate this from AudioEvent.
	/// </summary>
	[System.Serializable]
	public class AudioSettings {

		[Header("AudioSource Options")]
		public AudioClip clip;
		public AudioMixerGroup outputAudioMixerGroup;

		//bypass
		//bypass
		//bypass

		public bool playOnAwake;
		public bool loop;

		//priority

		[Range(0f,1f)]
		public float volume = 1f;

		[Range(-3f,3f)]
		public float pitch = 1f;

		[Range(-1f,1f)]
		public float panStereo = 0f;

		[Range(0f,1f)]
		public float spatialBlend = 0f;

		[Header("Playback Options")]
		public bool fadeIn;
		public bool fadeOut;

		//reverbZoneMix
	}
}
