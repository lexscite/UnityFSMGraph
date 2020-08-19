using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace PaperStag.FSM
{
	public class StateNode : FSMNode
	{
		[Input(backingValue: ShowBackingValue.Never,
            connectionType: ConnectionType.Multiple)]
		public FSMNode _from;
		[Output(backingValue: ShowBackingValue.Never,
            connectionType: ConnectionType.Multiple)]
		public FSMNode _to;
        [Output(backingValue: ShowBackingValue.Never,
            connectionType: ConnectionType.Multiple)]
        public StateNode _exitState;

        [SerializeReference]
		[SelectImpl(typeof(State))]
		protected State _implementation;
		public State State => _implementation;

        protected FSMGraph _fsmGraph;

		private List<Condition> _conditions;
        public IReadOnlyList<Condition> Conditions
        {
            get
            {
                if (_conditions == null)
                {
                    _conditions = new List<Condition>();
                    foreach (var inputNode
                        in GetInputValues(nameof(_from), _from))
                    {
                        if (inputNode is ConditionNode conditionNode)
                        {
                            _conditions.Add(conditionNode.Condition);
                        }
                    }
                }

                return _conditions;
            }
        }

        public void InitState()
        {
            _fsmGraph = graph as FSMGraph;
			State.Init(this);

            var ports = GetOutputPort(nameof(_to)).GetConnections();

            foreach (var port in ports)
            {
                if (port.node is ConditionNode conditionNode)
                {
                    conditionNode.OnSatisfied
                        += HandleOnConditionNodeSatisfied;
                }
            }

            _implementation.OnCompleted += HandleOnStateCompleted;
        }

        private void HandleOnConditionNodeSatisfied(ConditionNode node)
        {
            var fsmGraph = graph as FSMGraph;
            if (fsmGraph.CurrentNode == this)
            {
                fsmGraph.CurrentNode = node.To;
            }
        }

        private void HandleOnStateCompleted()
        {
            var exitNode = GetOutputPort(nameof(_exitState))
                .Connection.node as StateNode;

            if (exitNode != null)
            {
                _fsmGraph.CurrentNode = exitNode;
            }
            else
            {
                Debug.LogError($"FSM error. {State} " +
                    $"doesn't have exit state node");
            }
        }

        public override object GetValue(NodePort port)
		{
			return this;
		}

        public void OnEnter()
        {
            State.OnEnter();
        }

        public void OnExit()
        {
            State.OnExit();
        }
    }
}