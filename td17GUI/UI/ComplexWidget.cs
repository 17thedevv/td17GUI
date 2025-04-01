using SFML.Graphics;
using td17GUI.Graphics;
using td17GUI.Utilities;

namespace td17GUI.UI
{
    public abstract class ComplexWidget : ShapeWidget
    {
        protected TeaText teaText = new TeaText();

        protected ComplexWidget()
        {
            Init();
        }

        protected ComplexWidget(int x, int y, uint width, uint height) : base(x, y, width, height)
        {
            Init();
        }

        protected ComplexWidget(int x, int y, uint width, uint height, string text) : base(x, y, width, height)
        {
            Init();
            teaText.setContent(text);
        }

        public override void Init()
        {
            teaText.Init(new SFML.System.Vector2f(x, y), width, height);
        }

        public override void Draw(RenderWindow window)
        {
            base.Draw(window);
            window.Draw(this.teaText.getText());
        }

        public void setTextAlign(TextAlign textAlign)
        {
            teaText.setTextAlign(textAlign);
        }


        public void setContent(string text) => teaText.setContent(text);
        public void AppendContent(string text) => teaText.AppendContent(text);

        public override void setPosition(int x, int y)
        {
            base.setPosition(x, y);
            this.teaText.setPosition(new SFML.System.Vector2f(x, y));
        }

        public override void setSize(uint width, uint height)
        {
            base.setSize(width, height);
        }
    }
}
