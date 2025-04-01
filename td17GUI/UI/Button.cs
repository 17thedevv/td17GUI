using SFML.Window;

namespace td17GUI.UI
{
    public class Button : InteractiveWidget, IInteractiveOnclick
    {
        private List<Action> actions = new List<Action>();

        public Button()
        {

        }

        public Button(int x, int y, uint width, uint height) : base(x, y, width, height)
        {

        }



        public void addOnclickEvent(Action action)
        {
            actions.Add(action);
        }

        public override void HandleMouseButtonPressed(MouseButtonEventArgs e)
        {
            if (!isVisible) return;

            if (e.X >= x && e.X <= x + (int)width &&
                e.Y >= y && e.Y <= y + (int)height)
            {
                foreach (var action in this.actions)
                {
                    action.Invoke();
                }
            }

        }

        public void removeOnclickEvent(Action action)
        {
            actions.Remove(action);
        }
    }
}
