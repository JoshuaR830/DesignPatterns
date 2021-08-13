using System;

namespace DesignPatternsSampleApplication.Multiplayer
{
    public class OnTrialState : IState
    {
        // Every state needs reference to subscription manager
        // Need to modify state in the Expire.Pay methods
        private SubscriptionManager _manager;
        
        public OnTrialState(SubscriptionManager manger)
        {
            _manager = manger;
        }
        
        public void Expire()
        {
            Console.WriteLine("Trial expired");
            _manager.CurrentState = new TrialExpiredState(_manager);
        }

        public void Pay()
        {
            _manager.CurrentState = new PaidState(_manager);
        }
    }
}