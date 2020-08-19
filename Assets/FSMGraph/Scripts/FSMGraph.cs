using System;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace PaperStag.FSM
{
    public abstract class FSMGraph : NodeGraph
    {
        public event Action<string> OnTrigger = trigger => { };

        [SerializeField]
        protected EnterNode _enterNode;

        protected StateNode _currentNode;
        public StateNode CurrentNode
        {
            get { return _currentNode; }
            set
            {
                if (_currentNode != null) _currentNode.OnExit();
                _currentNode = value;
                _currentNode.OnEnter();
            }
        }

        private List<StateNode> _stateNodes;
        public IReadOnlyList<StateNode> StateNodes
        {
            get
            {
                if (_stateNodes == null)
                {
                    _stateNodes = new List<StateNode>();
                    foreach (var node in nodes)
                    {
                        if (node is StateNode stateNode)
                        {
                            _stateNodes.Add(stateNode);
                        }
                    }
                }

                return _stateNodes.AsReadOnly();
            }
        }

        private List<ConditionNode> _conditionNodes;
        public IReadOnlyList<ConditionNode> ConditionNodes
        {
            get
            {
                if (_conditionNodes == null)
                {
                    _conditionNodes = new List<ConditionNode>();
                    foreach (var node in nodes)
                    {
                        if (node is ConditionNode conditionNode)
                        {
                            _conditionNodes.Add(conditionNode);
                        }
                    }
                }

                return _conditionNodes.AsReadOnly();
            }
        }

        public void Start()
        {
            if (_enterNode == null)
            {
                _enterNode = nodes.Find(
                    a => a.GetType() == typeof(EnterNode)) as EnterNode;
            }

            CurrentNode = _enterNode.StartNode;
        }

        public virtual void Init(UnityEngine.Object initObject)
        {
            foreach (var stateNode in StateNodes)
            {
                stateNode.InitState();
            }

            foreach (var conditionNode in ConditionNodes)
            {
                conditionNode.InitCondition();
            }
        }

        public void Trigger(string trigger)
        {
            OnTrigger.Invoke(trigger);
        }
    }
}
