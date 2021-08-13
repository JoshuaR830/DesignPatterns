namespace DesignPatternsSampleApplication.Battlefields
{
    public class SnowyBattlefield : BattlefieldTemplate
    {
        public override string DescribeGround()
        {
            return "The ground is cold";
        }

        public override string DescribeClimate()
        {
            return "The climate is chilly and there is a strong wind";
        }

        public override string DescribeEffects()
        {
            return "It is hard to see";
        }
    }
}