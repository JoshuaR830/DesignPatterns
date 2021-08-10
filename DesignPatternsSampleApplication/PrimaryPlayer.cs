using DesignPatternsSampleApplication.Weapons;

namespace DesignPatternsSampleApplication
{
    /// This is a singleton
    /// Could be seen to violate the Single Responsibility principle - has to create itself - extra responsibilities
    /// Better approach could be to use dependency injection
    public sealed class PrimaryPlayer
    {

        /// <summary>
        /// A reference to the player - must be private so that it doesn't get modified
        /// Use a getter to access it publicly
        /// </summary>
        private static readonly PrimaryPlayer _instance;
        
        /// <summary>
        /// Use the interface to achieve loose coupling
        /// Just need to initialise a new weapon
        /// </summary>
        public IWeapon Weapon { get; set; }

        /// <summary>
        /// Used before first use of a class
        /// Initialise the PrimaryPlayer only when we need it and only once
        /// Benefits:
        /// Lazy loading - initialise only when needed
        /// Thread safety - only runs once in whole domain
        /// </summary>
        static PrimaryPlayer()
        {
            _instance = new PrimaryPlayer()
            {
                Name = "Joshua",
                Level = 1,
                Armour = 25,
                Health = 100
            };
        }
        
        
        public string Name { get; set; }
        public int Level { get; set; }
        public int Armour { get; set; }
        public int Health { get; set; }

        /// Private constructor - prevent it from being instantiated
        /// But now no access to the player at all
        private PrimaryPlayer()
        {
            
        }

        /// <summary>
        ///  Return readonly backing field - need to have an instance to return
        /// Allow the instance to be accessed
        /// </summary>
        public static PrimaryPlayer Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}