using SFML.Graphics;
using SFML.Window;

namespace td17GUI.UI
{
    public abstract class Widget : IWidget
    {
        protected int x;
        protected int y;
        protected uint width;
        protected uint height;
        protected bool isVisible = true;


        public Widget() { }

        public Widget(int x, int y, uint width, uint height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public bool getVisible() => isVisible;

        public void setVisible(bool visible) => isVisible = visible;

        public virtual void setSize(uint width, uint height)
        {
            this.width = width;
            this.height = height;
        }

        public virtual void setPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int getX() => x;
        public int getY() => y;
        public uint getWidth() => width;
        public uint getHeight() => height;

        public virtual void HandleMouseButtonPressed(MouseButtonEventArgs e) { }
        public virtual void HandleMouseMoved(MouseMoveEventArgs e) { }
        public virtual void HandleKeyPressed(KeyEventArgs e) {  }

        public abstract void Draw(RenderWindow window);
    }
}