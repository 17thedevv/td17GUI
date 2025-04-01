
namespace td17GUI.UI
{
    public interface ILayout
    {
        void ArrangeWidgets(int x, int y, uint width, uint height, List<IWidget> widgets);
    }

    public abstract class Layout : ILayout
    {
        protected uint padding = 5;

        protected Layout() { }
        public void setPadding(uint padding) => this.padding = padding;
        public uint getPadding() => this.padding;
        public abstract void ArrangeWidgets(int x, int y, uint width, uint height, List<IWidget> widgets);
    }
}
