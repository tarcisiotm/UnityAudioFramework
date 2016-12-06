﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityAudioFramework{
	
	public static class AudioFactory {

		public static AudioOneShot InstantiateAudioOneShot(AudioClip p_audioClip = null, AudioSettings p_audioSettings = null)
		{
			GameObject go = new GameObject ("Audio One Shot"); //TODO null check to add name
			AudioOneShot audioOneShot = go.AddComponent <AudioOneShot>();

			audioOneShot.Init (p_audioClip, p_audioSettings);
			return audioOneShot;
		}

		public static AudioLoop InstantiateAudioLoop(AudioClip p_audioClip = null, AudioSettings p_audioSettings = null)
		{
			GameObject go = new GameObject ("Audio Loop");
			AudioLoop audioLoop = go.AddComponent <AudioLoop>();

			audioLoop.Init (p_audioClip, p_audioSettings);
			return audioLoop;
		}

	}

}