namespace td17GUI.UI
{
    public interface IContainer
    {
        void addWidget(IWidget widget);
        bool removeWidget(IWidget widget);
    }
}
