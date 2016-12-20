using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityAudioFramework{
	
	public static class AudioFactory {

		public static AudioOneShot InstantiateAudioOneShot(AudioSettings p_audioSettings = null)
		{
			GameObject go = new GameObject ("Audio One Shot"); //TODO null check to add name
			AudioOneShot audioOneShot = go.AddComponent <AudioOneShot>();

			audioOneShot.Init (p_audioSettings);
			return audioOneShot;
		}

		public static AudioLoop InstantiateAudioLoop(AudioSettings p_audioSettings = null)
		{
			GameObject go = new GameObject ("Audio Loop"); //TODO null check to add name
			AudioLoop audioLoop = go.AddComponent <AudioLoop>();

			audioLoop.Init (p_audioSettings);
			return audioLoop;
		}

	}

}