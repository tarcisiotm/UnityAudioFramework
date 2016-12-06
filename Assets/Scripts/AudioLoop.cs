using UnityEngine;
using System.Collections;

namespace UnityAudioFramework
{
	/// <summary>
	/// Audio that by default will keep playing and looping
	/// </summary>
	public class AudioLoop : AudioEvent
	{
		public override void Init (AudioClip p_audioClip = null, AudioSettings p_audioSettings = null)
		{
			AudioSettings audioSettings = p_audioSettings == null ? AudioSettingsTemplates.GetOneShotSettings (p_audioClip) : p_audioSettings;
			base.Init (p_audioClip, audioSettings);
		}
	}
}
