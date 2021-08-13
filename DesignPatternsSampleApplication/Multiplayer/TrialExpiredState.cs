using System;

namespace DesignPatternsSampleApplication.Multiplayer
{
    public class TrialExpiredState : IState
    {
        private SubscriptionManager _manager;
        
        public TrialExpiredState(SubscriptionManager manger)
        {
            _manager = manger;
        }
        
        public void Expire()
        {
            Console.WriteLine("Can't expire, already expired");
        }

        public void Pay()
        {
            Console.WriteLine("Paid membership");
            _manager.CurrentState = new PaidState(_manager);
        }
    }
}