using UnityEngine;
using XNodeEditor;
using PaperStag.FSM;

namespace PaperStag.Editor
{
	[CustomNodeEditor(typeof(StateNode))]
	public class StateNodeEditor : NodeEditor
	{
		public override void OnHeaderGUI()
		{
			var node = target as StateNode;
			var graph = node.graph as FSMGraph;

			if (graph.CurrentNode == node) GUI.color = Color.green;

			var title = "State";
            if (node != null && node.State != null)
            {
			    title = node.State.GetType().Name;
            }

			GUILayout.Label(title, NodeEditorResources.styles.nodeHeader, GUILayout.Height(30));

			if (graph.CurrentNode == node) GUI.color = Color.white;
		}
    }
}