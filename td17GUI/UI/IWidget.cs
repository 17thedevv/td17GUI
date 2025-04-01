using SFML.Graphics;
using SFML.Window;

namespace td17GUI.UI
{
    public interface IWidget
    {
        bool getVisible();
        void setVisible(bool visible);
        void Draw(RenderWindow window);
        void HandleMouseButtonPressed(MouseButtonEventArgs e);
        void HandleMouseMoved(MouseMoveEventArgs e);
        void HandleKeyPressed(KeyEventArgs e);
        void setSize(uint width, uint height);
        void setPosition(int x, int y);
        int getX();
        int getY();
        uint getWidth();
        uint getHeight();
    }
}