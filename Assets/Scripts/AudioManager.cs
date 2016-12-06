using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityAudioFramework
{
	public class AudioManager : Singleton<AudioManager> {

		// Use this for initialization
		void Start () {
			AudioFactory.InstantiateAudioLoop ();
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		#region Audio Factory



		#endregion

	}
}
