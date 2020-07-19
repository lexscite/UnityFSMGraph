using XNode;

namespace PaperStag.FSM
{
    public class EnterNode : FSMNode
    {
        [Output(backingValue: ShowBackingValue.Never,
            connectionType: ConnectionType.Override)]
        public StateNode _startNode;

        public StateNode StartNode
            => GetOutputPort(nameof(_startNode)).Connection.node as StateNode;

        public override object GetValue(NodePort port)
        {
            return null;
        }
    }
}
