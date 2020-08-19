using System;

namespace PaperStag.FSM
{
    public abstract class Condition
    {
        public event Action<Condition> OnSatisfied = condition => { };

        protected ConditionNode _node;
        protected FSMGraph _graph;

        public void Init(ConditionNode node)
        {
            _node = node;
            _graph = _node.graph as FSMGraph;
            OnInit();
        }

        protected virtual void OnInit() { }

        protected void Satisfy() { OnSatisfied.Invoke(this); }
    }
}
