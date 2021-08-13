using System;
using System.Text;

namespace DesignPatternsSampleApplication.Battlefields
{
    public abstract class BattlefieldTemplate
    {
        
        // Template could define stuff that all subclasses share
        public string DescribeSky()
        {
            return "The battlefield sky is blue";
        }

        // Pure virtual functions - no implementation
        public abstract string DescribeGround();

        public abstract string DescribeClimate();

        public abstract string DescribeEffects();

        public string Describe()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(DescribeSky());
            builder.Append("\r\n");
            builder.Append(DescribeGround());
            builder.Append("\r\n");
            builder.Append(DescribeEffects());
            builder.Append("\r\n");
            builder.Append(DescribeClimate());
            builder.Append("\r\n");

            return builder.ToString();
        }
    }
}