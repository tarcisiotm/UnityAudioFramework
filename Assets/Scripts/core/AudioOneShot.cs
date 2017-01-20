using UnityEngine;
using System;
using System.Collections;

namespace UnityAudioFramework
{
	/// <summary>
	/// Audio that by default will be played once
	/// </summary>
	public class AudioOneShot : AudioEvent
	{
		Action OnFinishedPlaying = null;

		bool DestroyOnPlaybackEnd = true;

		public override void Init (AudioSettings p_audioSettings = null)
		{
			AudioSettings audioSettings = p_audioSettings == null ? AudioSettingsTemplates.GetOneShotSettings (p_audioSettings.clip) : p_audioSettings;
			base.Init (audioSettings);
		}

		public override void Play ()
		{
			base.Play ();
		}

		void Update()
		{
			CheckForEndOfAudio ();
		}

		/// <summary>
		/// Checks for end of audio and executes playbacks and/or destroys the game object afterwards. This could possibly be moved to update just to have one less operation.
		/// </summary>
		void CheckForEndOfAudio()
		{
			if (PlaybackStateAudio == PlaybackState.PLAYING)
			{
				if (!IsPlaying)
				{
					SetPlaybackState (PlaybackState.DONE_PLAYING);
					PlayAction (OnFinishedPlaying);

					if (DestroyOnPlaybackEnd)
					{
						DestroyAudioObject ();
					}
				}
			}
		}


	}
}