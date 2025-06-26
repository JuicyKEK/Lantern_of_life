using System;

namespace Game.Scripts.InputController
{
    public interface IInputActions
    {
        void AddPressingButtonFAction(Action action);
        void AddPressingButtonEAction(Action action);
        void AddPressingMouseLeftButtonDownAction(Action action);
        void AddPressingMouseLeftButtonUpAction(Action action);
    }
}