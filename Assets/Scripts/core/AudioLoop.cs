using UnityEngine;
using System.Collections;

namespace UnityAudioFramework
{
	/// <summary>
	/// Audio that by default will keep playing and looping
	/// </summary>
	public class AudioLoop : AudioEvent
	{
		public override void Init (AudioSettings p_audioSettings = null)
		{
			AudioSettings audioSettings = p_audioSettings == null ? AudioSettingsTemplates.GetOneShotSettings (p_audioSettings.clip) : p_audioSettings;
			base.Init (audioSettings);
		}
	}
}
