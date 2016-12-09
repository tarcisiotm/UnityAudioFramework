using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace UnityAudioFramework
{
	public class AudioArea : MonoBehaviour { //TODO think about this name if it properly portrays what it is supposed to do

		public bool FadeOutOnSceneChanged = true;

		void Awake()
		{
			AudioManager.Instance.AddArea (this);
		}

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}
	}
}
