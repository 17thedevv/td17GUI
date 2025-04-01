using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace td17GUI.UI
{
    public class InteractiveWidget : ComplexWidget
    {
        public InteractiveWidget() { }

        public InteractiveWidget(int x, int y, uint width, uint height) : base(x, y, width, height)
        {
        }

        public override void HandleKeyPressed(KeyEventArgs e)
        {
            
        }

        public override void HandleMouseButtonPressed(MouseButtonEventArgs e)
        {
            
        }

        public override void HandleMouseMoved(MouseMoveEventArgs e)
        {
            
        }
    }
}
