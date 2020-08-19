using System;
using UnityEngine;

namespace PaperStag.FSM
{
    public abstract class State
    {
        // TODO: Remove after issue #1183547 will get fixed
        [SerializeField]
        [HideInInspector]
        protected float _1183547_fix;

        public event Action OnCompleted = () => { };

        protected FSMGraph _graph;
        protected StateNode _node;

        public void Init(StateNode node)
        {
            _node = node;
            _graph = _node.graph as FSMGraph;
            OnInit();
        }

        public virtual void OnEnter() { }
        public virtual void OnExit() { }

        protected virtual void OnInit() { }

        protected void Complete()
        {
            OnCompleted.Invoke();
        }
    }

    public class EmptyState : State { }
}