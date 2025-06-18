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
        
        [SerializeField] GameObject m_LanternObject;

        private ILanternPowerTimerServices m_LanternPowerTimerServices;
        private bool m_IsLanternActive;
        
        public void MethodInit()
        {
            m_InputActions.AddPressingButtonFAction(ActivationLantern);
            m_IsLanternActive = m_LanternObject.activeSelf;
            m_LanternPowerTimerServices = new LanternPowerTimerServices(DeactivateLantern);
        }

        public void MethodStart()
        {
            
        }
        
        public void CustomUpdate()
        {
            if (m_IsLanternActive)
            {
                Debug.Log(m_LanternPowerTimerServices.RemainingTime);
            }
        }

        private void ActivationLantern()
        {
            if (!CanActivateLantern())
            {
                return;
            }
            
            m_IsLanternActive = !m_IsLanternActive;
            
            m_LanternObject.SetActive(m_IsLanternActive);

            if (m_IsLanternActive)
            {
                m_LanternPowerTimerServices.StartTimer(10, 4);
            }
        }

        private void DeactivateLantern()
        {
            m_IsLanternActive = false;
            m_LanternObject.SetActive(m_IsLanternActive);
        }

        private bool CanActivateLantern()
        {
            return true;
        }
    }
}
