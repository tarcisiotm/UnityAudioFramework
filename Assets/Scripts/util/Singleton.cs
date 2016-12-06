using UnityEngine;

namespace UnityAudioFramework
{
	public abstract class Singleton<T> : MonoBehaviour where T : Component
	{
		protected static T m_instance = null;

		public static T Instance
		{
			get
			{
				if (m_instance != null)
				{
					return m_instance;
				}

				return InstantiateObject();
			}
		}


		static T InstantiateObject()
		{
			if (m_instance == null)
			{
				GameObject singleton = new GameObject();
				m_instance = singleton.AddComponent<T>();
				singleton.name = "(singleton) "+ typeof(T).ToString();

				(m_instance as Singleton<T>).Init();

				DontDestroyOnLoad(m_instance.gameObject);
			}

			return m_instance;
		}

		protected virtual void Init()
		{

		}

		public virtual void Awake()
		{
			if (m_instance != null && m_instance != this)
			{
				Destroy (gameObject);
				return;
			}

			DontDestroyOnLoad (gameObject);
		}

		public virtual void OnDisable()
		{
			if (m_instance == this)
			{
				m_instance = null;
			}
		}
	}
}
