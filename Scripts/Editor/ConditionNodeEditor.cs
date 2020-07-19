using UnityEngine;
using XNodeEditor;
using PaperStag.FSM;

namespace PaperStag.Editor
{
    [CustomNodeEditor(typeof(ConditionNode))]
    public class ConditionNodeEditor : NodeEditor
    {
        public override void OnHeaderGUI()
        {
            var node = target as ConditionNode;

            var title = "Condition";
            if (node != null && node.Condition != null)
            {
                title = node.Condition.GetType().Name;
            }

            GUILayout.Label(title, NodeEditorResources.styles.nodeHeader, GUILayout.Height(30));
        }

        public override void OnBodyGUI()
        {
            base.OnBodyGUI();
        }
    }
}