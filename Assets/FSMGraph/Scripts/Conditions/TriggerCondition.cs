using UnityEngine;

namespace PaperStag.FSM
{
    public class TriggerCondition : Condition
    {
        [SerializeField]
        protected string _trigger;

        protected override void OnInit()
        {
            _graph.OnTrigger += HandleOnTrigger;
        }

        private void HandleOnTrigger(string trigger)
        {
            if (_trigger == trigger) Satisfy();
        }
    }
}
