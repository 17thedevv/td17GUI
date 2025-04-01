namespace td17GUI.UI
{
    public class FlowLayout : Layout
    {
        
        public override void ArrangeWidgets(int x, int y, uint width, uint height, List<IWidget> widgets)
        {
            if (widgets == null || widgets.Count == 0)
                return;

            int currentX = x;
            int currentY = y;
            int rowMaxHeight = 0;

            foreach (IWidget widget in widgets)
            {
                int widgetWidth = (int)widget.getWidth();
                int widgetHeight = (int)widget.getHeight();

                if(widget.getWidth() > width) widget.setSize(width, widget.getHeight());

                
                if (currentX != x && currentX + widgetWidth > x + (int)width)
                {
                    currentX = x;
                    currentY += rowMaxHeight + (int)padding; 
                    rowMaxHeight = 0;
                }

                
                widget.setPosition(currentX, currentY);

                
                currentX += widgetWidth + (int)padding;

                
                if (widgetHeight > rowMaxHeight)
                    rowMaxHeight = widgetHeight;
            }
        }
    }
}