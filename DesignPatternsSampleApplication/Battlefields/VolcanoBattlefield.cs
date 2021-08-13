namespace DesignPatternsSampleApplication.Battlefields
{
    // Need to implement specific methods
    // All subclasses need to implement them
    // The whole battlefield is built
    public class VolcanoBattlefield : BattlefieldTemplate
    {
        public override string DescribeGround()
        {
            return "There is fog and dust everywhere";
        }

        public override string DescribeClimate()
        {
            return "There are flames jumping from underneath";
        }

        public override string DescribeEffects()
        {
            return "The ground is rocky and unstable";
        }
    }
}