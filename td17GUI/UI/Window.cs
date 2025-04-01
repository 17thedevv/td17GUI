using SFML.Graphics;
using SFML.Window;

namespace td17GUI.UI
{
    public class Window : IContainer
    {
        private RenderWindow? window;

        private List<Panel> panels = new List<Panel>();
        private List<IWidget> widgets = new List<IWidget>();

        private uint width;
        private uint height;
        private string title;

        private bool isFixedSize = false;

        private uint initialWidth;
        private uint initialHeight;


        public Window(string title)
        {
            this.title = title;
        }

        private Color backgroundColor = Utilities.TeaColor.gray;

        public Window(uint width, uint height)
        {
            this.width = width;
            this.height = height;
            this.title = "";
        }

        public Window(uint width, uint height, string title)
        {
            this.width = width;
            this.height = height;
            this.title = title;
        }

        public Window(uint width, uint height, string title, Color backgroundColor) : this(width, height, title)
        {
            this.backgroundColor = backgroundColor;
        }

        protected void Init()
        {
            initialWidth = this.width;
            initialHeight = this.height;
            window = new RenderWindow(new SFML.Window.VideoMode(this.width, this.height), this.title);
            window.Closed += (sender, e) => window.Close();

            window.MouseButtonPressed += (sender, e) => OnMouseButtonPressed(e);
            window.MouseMoved += (sender, e) => OnMouseMoved(e);
            window.KeyPressed += (sender, e) => OnKeyPressed(e);
            window.Resized += (sender, e) => OnWindowResize(e);
        }

        public void Run()
        {
            Init();
            foreach(var panel in this.panels)
            {
                panel.ArrangeWidgets();
            }    
            while (window.IsOpen)
            {
                
                window.Clear(this.backgroundColor);
                window.DispatchEvents();
                foreach (var widget in widgets.ToList())
                {
                    if(widget.getVisible())
                    {
                        widget.Draw(window);
                    }    
                }
                foreach(var panel in panels.ToList())
                {
                    panel.Draw(window);
                }    

                window.Display();
            }

        }

        public void ShutDown()
        {
            this.window.Close();
        }

        

        public RenderWindow getWindowRenderer()
        {
            return this.window;
        }

        private void OnMouseButtonPressed(MouseButtonEventArgs e)
        {
            foreach (var panel in this.panels)
            {
                foreach(var widget in panel.getWidgets())
                {
                    widget.HandleMouseButtonPressed(e);
                }    
            }


            foreach (var widget in widgets.ToList())
            {
                widget.HandleMouseButtonPressed(e);
            }
        }

        private void OnMouseMoved(MouseMoveEventArgs e)
        {
            foreach (var panel in this.panels)
            {
                foreach (var widget in panel.getWidgets())
                {
                    widget.HandleMouseMoved(e);
                }
            }

            foreach (var widget in widgets.ToList())
            {
                widget.HandleMouseMoved(e);
            }
        }

        private void OnKeyPressed(KeyEventArgs e)
        {
            foreach (var panel in this.panels)
            {
                foreach (var widget in panel.getWidgets())
                {
                    widget.HandleKeyPressed(e);
                }
            }

            foreach (var widget in widgets.ToList())
            {
                widget.HandleKeyPressed(e);
            }
        }

        private void OnWindowResize(SizeEventArgs e)
        {
            if (!isFixedSize) return;
            /*
            float widthRatio = (float)e.Width / initialWidth;
            float heightRatio = (float)e.Height / initialHeight;

            Console.WriteLine($"Tỷ lệ thay đổi - Width: {widthRatio}, Height: {heightRatio}");

            // Cập nhật các widget dựa trên tỷ lệ
            foreach (var widget in widgets)
            {
                widget.HandleWindowResize(e, widthRatio, heightRatio);
            }*/
        }

        public void setBackGroundColor(Color backGroundColor)
        {
            this.backgroundColor = backGroundColor;
        }

        public void AddKeyPressEvent(Action action)
        {
            
        }

        public void addWidget(IWidget widget)
        {
            widgets.Add(widget);
        }

        public bool removeWidget(IWidget widget)
        {
            return widgets.Remove(widget);
        }

        public void addPanel(Panel panel) => this.panels.Add(panel);
        public bool removePanel(Panel panel) =>  this.removePanel(panel); 

        public void setFixedSize(bool fixedSize) => this.isFixedSize = fixedSize;
        public bool getFixedSize() => this.isFixedSize;
    }
}
