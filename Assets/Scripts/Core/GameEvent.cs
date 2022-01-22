using UnityEngine;
using System.Collections.Generic;

namespace Core.Events
{
	[CreateAssetMenu]
	public class GameEvent : ScriptableObject
	{
		private List<GameEventListener> listeners = new List<GameEventListener>();

		public void Raise()
		{
			Debug.Log("<color=blue>RAISING EVENT: "+ name+ "</color>");
			for (int i = listeners.Count -1; i >= 0; i--)
			{
				listeners[i].OnEventRaised();
			}
		}

		public void RegisterListener(GameEventListener listener)
		{
			listeners.Add(listener);
		}

		public void UnRegisterListener(GameEventListener listener)
		{
			listeners.Remove(listener);
		}

		public void UnregisterAllListeners()
		{
			listeners.Clear();
		}
	}
}
