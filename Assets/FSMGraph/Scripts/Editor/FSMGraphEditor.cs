using UnityEngine;
using XNodeEditor;
using PaperStag.FSM;

namespace PaperStag.Editor
{
	[CustomNodeGraphEditor(typeof(FSMGraph))]
	public class FSMGraphEditor : NodeGraphEditor
	{
        public override void OnOpen()
        {
            base.OnOpen();
			window.titleContent = new GUIContent("FSM");
        }

        public override string GetNodeMenuName(System.Type type)
		{
			if (type.Namespace == "PaperStag.FSM")
			{
				return type.Name;
			}
			else
			{
				return null;
			}
		}
	}
}
