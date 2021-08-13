namespace Common
{
    public class DefenceDecorator : CardDecorator
    {
        // Make attack 0 for it is always 0
        // Improve simplicity of initialisation - fewer arguments and visually distinguish
        public DefenceDecorator(Card card, string name, int defence) : base(card, name, 0, defence)
        {
        }
    }
}