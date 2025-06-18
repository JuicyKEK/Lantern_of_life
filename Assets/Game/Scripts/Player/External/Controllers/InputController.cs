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
        }
        
        public void AddPressingButtonFAction(Action action)
        {
            m_PressingButtonF += action;
        }

        public void AddPressingButtonEAction(Action action)
        {
            m_PressingButtonE += action;
        }
    }
}