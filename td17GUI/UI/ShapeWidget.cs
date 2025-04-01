using SFML.Graphics;
using SFML.Window;
using td17GUI.Graphics;
using td17GUI.Utilities;

namespace td17GUI.UI
{
    public abstract class ShapeWidget : Widget
    {
        protected TeaRecthape TeaRect = new TeaRecthape();

        protected ShapeWidget()
        {
            Init();
        }

        protected ShapeWidget(int x, int y, uint width, uint height) : base(x, y, width, height)
        {
            Init();
        }

        public virtual void Init()
        {
            this.TeaRect.setPosition(this.x, this.y);
            this.TeaRect.setSize(this.width, this.height);
        }

        public override void Draw(RenderWindow window) => window.Draw(this.TeaRect.getRect());

        public override void setPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.TeaRect.setPosition(x, y);
        }

        public override void setSize(uint width, uint height)
        {
            base.setSize(width, height);
            this.TeaRect.setSize((uint)width, (uint)height);
        }

        public void setFillColor(Color color) => this.TeaRect.setFillColor(color);
    }
}
