using SFML.Graphics;
using SFML.Graphics.Glsl;
using SFML.System;

namespace td17GUI.Graphics
{
    public class TeaRecthape
    {
        private RectangleShape rect = new RectangleShape();

        public TeaRecthape()
        {
            Init();
        }

        public TeaRecthape(uint width, uint height)
        {
            Init();
            this.setSize(width, height);
        }

        public void Init()
        {
            rect.OutlineThickness = 1;
            rect.OutlineColor = Color.Black;
            rect.FillColor = Color.Transparent;
        }

        public void Init(uint width, uint height, int x, int y)
        {
            Init();
            setSize(width, height);
            setPosition(x, y);
        }

        public void Init(uint width, uint height, int x, int y, Color outline)
        {
            rect.OutlineThickness = 1;
            rect.OutlineColor = outline;
            rect.FillColor = Color.Transparent;
            setPosition(x, y);
            setSize(width, height);
        }

        public void setSize(uint width, uint height) => rect.Size = new Vector2f(width, height);
        public Vector2f getSize() => rect.Size;
        public RectangleShape getRect() => rect;
        public void setPosition(int x, int y) => rect.Position = new Vector2f(x, y);
        public void setFillColor(Color color) => rect.FillColor = color;    
    }
}
