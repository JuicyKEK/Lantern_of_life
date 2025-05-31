using System.Collections.Generic;
using JuicyDI;
using JuicyDI.Attributes;
using UnityEngine;

namespace Game.Scripts.Game.GameStarter
{
    [JDIMonoController]
    public class TestRoomStarter : MonoBehaviour
    {
        [Inject] private List<ISequence> m_TestStarter;

        [SerializeField] private MainJDIController m_MainJDIController;
        
        private GameSequenceController m_GameSequenceController;
        
        private void Start()
        {
            m_MainJDIController.Init();
            m_GameSequenceController = new GameSequenceController(m_TestStarter);
        }
    }
}
