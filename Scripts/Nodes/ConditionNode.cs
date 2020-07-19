using System;
using UnityEngine;
using XNode;

namespace PaperStag.FSM
{
    public class ConditionNode : FSMNode
    {
        public event Action<ConditionNode> OnSatisfied = node => { };

        [Input(backingValue: ShowBackingValue.Never,
            connectionType: ConnectionType.Multiple,
            typeConstraint: TypeConstraint.Inherited)]
        public FSMNode _from;
        [Output(backingValue: ShowBackingValue.Never,
            connectionType: ConnectionType.Override)]
        public FSMNode _to;

        [SerializeReference]
        [SelectImplementation(typeof(Condition))]
        protected Condition _implementation;
        public Condition Condition => _implementation;

        public StateNode To => GetOutputPort("_to").Connection.node as StateNode;

        public void InitCondition()
        {
            Condition.Init(this);
            Condition.OnSatisfied += HandleOnConditionSatisfied;
        }

        public override object GetValue(NodePort port)
        {
            return this;
        }

        private void HandleOnConditionSatisfied(Condition condition)
        {
            OnSatisfied.Invoke(this);
        }
    }
}
