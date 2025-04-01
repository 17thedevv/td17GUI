namespace td17GUI.UI
{
    public class Label : ComplexWidget
    {
        private bool canFixedSize = false;

        public Label()
        {

        }

        public Label(int x, int y, uint width, uint height) : base(x, y, width, height)
        {

        }

        public Label(int x, int y, uint width, uint height, string text) : base(x, y, width, height, text)
        {

        }

        public override void setSize(uint width, uint height)
        {
            if (!canFixedSize) return;
            base.setSize(width, height);
        }

        public void setCanFixedSize(bool isFixed) => canFixedSize = isFixed;
        public bool getCanFixedSize() => canFixedSize;

    }
}
