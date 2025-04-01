using SFML.Graphics;

namespace td17GUI.Utilities
{
    public class TeaColor
    {
        public static Color gray = new Color(120, 125, 120, 1);


        public static Color getColorRGBA(byte red, byte green, byte blue, byte alpha)
        {
            return new Color(red, green, blue, alpha);
        }
        public static Color getColorRGBA(byte red, byte green, byte blue)
        {
            return new Color(red, green, blue, 0);
        }
        public static Color getColorRGBA(byte red, byte green)
        {
            return new Color(red, green, 0, 0);
        }
        public static Color getColorRGBA(byte red)
        {
            return new Color(red, 0, 0, 0);
        }
    }
}
