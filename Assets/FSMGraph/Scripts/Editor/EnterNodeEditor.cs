using UnityEngine;
using XNodeEditor;
using PaperStag.FSM;

namespace PaperStag.Editor
{
    [CustomNodeEditor(typeof(EnterNode))]
    public class ConfigNodeEditor : NodeEditor
    {
        public override void OnHeaderGUI()
        {
            string title = "Enter";
            GUILayout.Label(title, NodeEditorResources.styles.nodeHeader, GUILayout.Height(30));
        }

        public override void OnBodyGUI()
        {
            base.OnBodyGUI();
        }

        public override Color GetTint()
        {
            return Color.green;
        }
    }
}