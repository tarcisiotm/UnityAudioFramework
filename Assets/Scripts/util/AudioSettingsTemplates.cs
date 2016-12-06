using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

namespace UnityAudioFramework
{
	public static class AudioSettingsTemplates {

		public static AudioSettings GetDefaultSettings(AudioClip clip = null)
		{
			AudioSettings audioSettings = new AudioSettings ();

			audioSettings.clip = clip;
			audioSettings.volume = 1f;
			audioSettings.fadeIn = true;
			audioSettings.fadeOut = true;
			audioSettings.spatialBlend = 0f;
			audioSettings.panStereo = 0;
			audioSettings.pitch = 1;

			return audioSettings;
		}

		public static AudioSettings GetLoopSettings(AudioClip clip = null)
		{
			AudioSettings audioSettings = new AudioSettings ();

			audioSettings.clip = clip;
			audioSettings.volume = 1f;
			audioSettings.fadeIn = true;
			audioSettings.fadeOut = true;
			audioSettings.spatialBlend = 0f;
			audioSettings.panStereo = 0;
			audioSettings.pitch = 1;
			audioSettings.loop = true;

			return audioSettings;
		}

		public static AudioSettings GetOneShotSettings(AudioClip clip = null)
		{
			AudioSettings audioSettings = new AudioSettings ();

			audioSettings.clip = clip;
			audioSettings.volume = 1f;
			audioSettings.fadeIn = false;
			audioSettings.fadeOut = false;
			audioSettings.spatialBlend = 0f;
			audioSettings.panStereo = 0;
			audioSettings.pitch = 1;
			audioSettings.loop = false;

			return audioSettings;
		}
		
	}
}
