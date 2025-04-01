using SFML.Graphics;
using td17GUI.Graphics;

namespace td17GUI.UI
{
    public class Panel : IContainer
    {
        protected ILayout layout = new GridLayout();
        protected List<IWidget> widgets = new List<IWidget>();

        protected int x;
        protected int y;
        protected uint width;
        protected uint height;

        protected TeaRecthape outline = new TeaRecthape();

        public Panel(int x, int y, uint width, uint height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            outline.Init(width, height, x, y, Color.White);
        }

        public Panel(ILayout layout, List<IWidget> widgets, int x, int y, uint width, uint height)
        {
            this.layout = layout;
            this.widgets = widgets;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            outline.Init(width, height, x, y, Color.White);
        }

        public void addWidget(IWidget widget)
        {
            widgets.Add(widget);
            ArrangeWidgets(); 
        }

        public bool removeWidget(IWidget widget)
        {
            return widgets.Remove(widget);
        }

        public void setLayout(ILayout layout)
        {
            this.layout = layout;
            ArrangeWidgets();
        }

        public void ArrangeWidgets()
        {
            layout.ArrangeWidgets(x, y, width, height, widgets);
        }

        public void Draw(RenderWindow window)
        {
            
            foreach (IWidget widget in widgets)
            {
                widget.Draw(window);
            }
            window.Draw(this.outline.getRect());
        }

        public List<IWidget> getWidgets() => widgets;
    }
}