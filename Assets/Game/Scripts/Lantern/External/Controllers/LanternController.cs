using Game.Scripts.InputController;
using JuicyDI;
using JuicyDI.Attributes;
using UnityEngine;

namespace Game.Scripts.Lantern
{
    [JDIMonoController]
    [SequenceParticipant(100)]
    public class LanternController : MonoBehaviour, ISequence, IUpdateSequence
    {
        [Inject] private IInputActions m_InputActions;
        
        [SerializeField] private LanternActivationController m_LanternLight;
        [SerializeField] private LanternTimerViewController m_LanternTimerViewController;

        private ILanternPowerTimerServices m_LanternPowerTimerServices;
        private bool m_IsLanternActive;
        private bool m_IsLanternFastModeActive;
        
        public void MethodInit()
        {
            m_InputActions.AddPressingButtonFAction(ActivationLantern);
            m_InputActions.AddPressingMouseLeftButtonDownAction(ActivatingFastMode);
            m_InputActions.AddPressingMouseLeftButtonUpAction(ActivatingFastMode);
            m_LanternPowerTimerServices = new LanternPowerTimerServices(DeactivateLantern, m_LanternTimerViewController);
        }

        public void MethodStart()
        {
            
        }
        
        public void CustomUpdate()
        {
            if (m_IsLanternActive)
            {
                m_LanternPowerTimerServices.UpdateTimeView();
            }
        }

        private void ActivationLantern()
        {
            if (!CanActivateLantern())
            {
                return;
            }
            
            if (m_IsLanternActive)
            {
                DeactivateLantern();
            }
            else
            {
                ActivateLantern();
            }
        }

        private void ActivatingFastMode()
        {
            if (!m_IsLanternActive)
            {
                return;
            }
            
            m_IsLanternFastModeActive = !m_IsLanternFastModeActive;
            m_LanternLight.SetFastLantern(m_IsLanternFastModeActive);
            m_LanternPowerTimerServices.SetFastTimer(m_IsLanternFastModeActive);
        }
        
        private void ActivateLantern()
        {
            m_IsLanternActive = true;
            m_IsLanternFastModeActive = false;
            m_LanternLight.ActivateLantern();
            m_LanternPowerTimerServices.StartTimer(10, 10);
        }
        
        private void DeactivateLantern()
        {
            m_IsLanternActive = false;
            m_IsLanternFastModeActive = false;
            m_LanternPowerTimerServices.StopTimer();
            m_LanternLight.DeactivateLantern();
        }

        private bool CanActivateLantern()
        {
            return true;
        }
    }
}
