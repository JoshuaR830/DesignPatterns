namespace DesignPatternsSampleApplication.Multiplayer
{
    // Manages the states
    public class SubscriptionManager
    {
        public IState CurrentState;

        public SubscriptionManager()
        {
            CurrentState = new OnTrialState(this);
        }
        
        
        // Call functions on the current state
        public void Expire()
        {
            CurrentState.Expire();
        }

        public void Pay()
        {
            CurrentState.Pay();
        }
    }
}