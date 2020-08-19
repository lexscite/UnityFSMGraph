using UnityEngine;

namespace PaperStag.FSM
{
    public class FSMBehaviour : MonoBehaviour
    {
        [SerializeField]
        protected FSMGraph _graph;
        [SerializeField]
        protected Object _initObject;

        public void Trigger(string trigger)
        {
            _graph.Trigger(trigger);
        }

        private void Awake()
        {
            _graph = _graph.Copy() as FSMGraph;
            _graph.Init(_initObject);
            _graph.Start();
        }
    }
}
