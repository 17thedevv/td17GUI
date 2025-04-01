namespace td17GUI.UI
{
    public class GridLayout : Layout
    {
        private uint columns = 1;
        private uint rows = 1;

        public GridLayout() { }

        public GridLayout(uint columns, uint rows)
        {
            this.columns = columns;
            this.rows = rows;
        }

        public override void ArrangeWidgets(int x, int y, uint width, uint height, List<IWidget> widgets)
        {
            if (widgets == null || widgets.Count == 0)
                return;

            // Tính kích thước của mỗi ô trong lưới
            uint cellWidth = width / columns;
            uint cellHeight = height / rows;

            for (int i = 0; i < widgets.Count; i++)
            {
                int currentRow = i / (int)columns;
                int currentCol = i % (int)columns;

                // Nếu số widget vượt quá số ô có sẵn, dừng sắp xếp
                if (currentRow >= rows)
                    break;

                // Tính vị trí gốc của ô trong lưới
                int cellX = x + currentCol * (int)cellWidth;
                int cellY = y + currentRow * (int)cellHeight;

                // Xác định vùng "nội bộ" của ô (không bao gồm padding)  
                // Vùng này sẽ là vùng nhận sự kiện của widget.
                int widgetX = cellX + (int)padding;
                int widgetY = cellY + (int)padding;
                uint widgetWidth = (cellWidth > 2 * padding) ? cellWidth - 2 * padding : 0;
                uint widgetHeight = (cellHeight > 2 * padding) ? cellHeight - 2 * padding : 0;

                // Cập nhật vị trí và kích thước của widget bằng vùng nội bộ
                widgets[i].setPosition(widgetX, widgetY);
                widgets[i].setSize(widgetWidth, widgetHeight);
            }
        }
    }
}