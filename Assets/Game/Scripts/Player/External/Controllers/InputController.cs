using System;
using JuicyDI;
using JuicyDI.Attributes;
using UnityEngine;

namespace Game.Scripts.InputController
{
    [JDIMonoController]
    [SequenceParticipant(50)]
    public class InputController : MonoBehaviour, ISequence, IUpdateSequence, IInputActions
    {
        private Action m_PressingButtonF;
        private Action m_PressingButtonE;
        private Action m_PressingMouseLeftButtonDown;
        private Action m_PressingMouseLeftButtonUp;

        public void MethodInit()
        {

        }

        public void MethodStart()
        {
            
        }

        public void CustomUpdate()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                m_PressingButtonF?.Invoke();
            }
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                m_PressingButtonE?.Invoke();
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                m_PressingMouseLeftButtonDown?.Invoke();
            }
            
            if (Input.GetMouseButtonUp(0))
            {
                m_PressingMouseLeftButtonUp?.Invoke();
            }
        }
        
        public void AddPressingButtonFAction(Action action)
        {
            m_PressingButtonF += action;
        }

        public void AddPressingButtonEAction(Action action)
        {
            m_PressingButtonE += action;
        }

        public void AddPressingMouseLeftButtonDownAction(Action action)
        {
            m_PressingMouseLeftButtonDown += action;
        }

        public void AddPressingMouseLeftButtonUpAction(Action action)
        {
            m_PressingMouseLeftButtonUp += action;
        }
    }
}