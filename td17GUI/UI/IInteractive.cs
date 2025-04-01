using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace td17GUI.UI
{
    public interface IInteractiveOnclick
    {
        void addOnclickEvent(Action action);
        void removeOnclickEvent(Action action);
    }
    public interface IInteractiveMouseMoved
    {
        void addMouseMovedEvent(Action action);
        void removeMouseMovedEvent(Action action);
    }
    public interface IInteractiveKeyPresssed
    {
        void addKeyPresssedEvent(Action action);
        void removeKeyPresssedEvent(Action action);
    }
}
