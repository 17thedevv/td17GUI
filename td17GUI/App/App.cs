using SFML.Graphics;
using td17GUI.UI;


namespace td17GUI.App
{
    public class App
    {
        static void Main(string[] args)
        {
            Window window = new Window(800, 600, "hlinh");

            TextBox textBox = new TextBox(200, 50);
            



            Panel panel = new Panel(200, 200, 300, 300);
            panel.addWidget(textBox);
            panel.setLayout(new FlowLayout());
            

            window.addPanel(panel);
            window.Run();

        }
    }
}
