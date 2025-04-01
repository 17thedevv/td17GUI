namespace td17GUI.UI
{

    public class BoxLayout : Layout
    {
        
        public Orientation orientation = Orientation.Horizontal;


        public override void ArrangeWidgets(int x, int y, uint width, uint height, List<IWidget> widgets)
        {
            if (widgets == null || widgets.Count == 0)
                return;

            int count = widgets.Count;

            if (orientation == Orientation.Horizontal)
            {
                // Tính tổng khoảng cách giữa các widget
                int totalSpacing = (int)padding * (count - 1);
                // Chiều rộng còn lại sau khi trừ khoảng cách
                int availableWidth = (int)width - totalSpacing;
                // Chiều rộng cho mỗi widget được chia đều
                int widgetWidth = availableWidth / count;
                // Sử dụng toàn bộ chiều cao của vùng bố trí
                int widgetHeight = (int)height;

                int currentX = x;
                for (int i = 0; i < count; i++)
                {
                    // Đặt vị trí cho widget thứ i
                    widgets[i].setPosition(currentX, y);
                    // Đặt kích thước widget = kích thước ô được cấp phát  
                    // (không trừ đi padding nào khác để vùng nhận sự kiện trùng với vùng hiển thị)
                    widgets[i].setSize((uint)widgetWidth, (uint)widgetHeight);
                    currentX += widgetWidth + (int)padding;
                }
            }
            else // Vertical
            {
                int totalSpacing = (int)padding * (count - 1);
                int availableHeight = (int)height - totalSpacing;
                int widgetHeight = availableHeight / count;
                int widgetWidth = (int)width; // Toàn bộ chiều rộng

                int currentY = y;
                for (int i = 0; i < count; i++)
                {
                    widgets[i].setPosition(x, currentY);
                    widgets[i].setSize((uint)widgetWidth, (uint)widgetHeight);
                    currentY += widgetHeight + (int)padding;
                }
            }
        }
    }
}