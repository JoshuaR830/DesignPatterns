using System;

namespace DesignPatternsSampleApplication.Multiplayer
{
    public class PaidState : IState
    {
        private SubscriptionManager _manager;

        public PaidState(SubscriptionManager manager)
        {
            _manager = manager;
        }
        
        public void Expire()
        {
            throw new InvalidOperationException("Can't expire a paid membership");
        }

        public void Pay()
        {
            throw new InvalidOperationException("Can't pay again'");
        }
    }
}