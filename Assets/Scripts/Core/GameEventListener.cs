using System;

namespace Core.Events
{
    public class GameEventListener
    {
        private event Action m_Response;

        public GameEventListener(GameEvent eventListeningTo, Action responseAction)
        {
            m_Response = responseAction;
            eventListeningTo.RegisterListener(this);
        }

        public void OnEventRaised()
        {
            m_Response.Invoke();
        }
    }
}
