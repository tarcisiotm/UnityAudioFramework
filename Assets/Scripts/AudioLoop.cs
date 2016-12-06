using UnityEngine;
using System.Collections;

namespace UnityAudioFramework
{
	/// <summary>
	/// Audio that by default will keep playing and looping
	/// </summary>
	public class AudioLoop : AudioEvent
	{
		public override void Init (AudioClip clip = null)
		{
			base.Init (clip);
			Setup (AudioSettingsTemplates.GetLoopSettings (clip));
		}
	}
}
