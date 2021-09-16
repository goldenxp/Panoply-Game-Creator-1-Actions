namespace GameCreator.Core
{
	using UnityEngine;
	using Opertoon.Panoply;
	
	#if UNITY_EDITOR
	using UnityEditor;
	#endif

	public class ActionDisableNavigation : IAction
	{
		public override bool InstantExecute(GameObject target, IAction[] actions, int index)
		{
			if (PanoplyCore.scene != null) 
			{
				PanoplyCore.scene.disableNavigation = true;
				PanoplyController controller = PanoplyCore.scene.GetComponent<PanoplyController>();
				if (controller)
				{
					controller.keyboardInput = false;
					controller.passiveInput = false;
				}
				
			}
				
			return true;
		}

		#if UNITY_EDITOR
		public static new string NAME = "Panoply/Disable Navigation";
		private const string NODE_TITLE = "Disable Navigation";
		private const string MSG = "Disables all navigation in Panoply Scene and its controller.";
		
		public override string GetNodeTitle()
		{
			return NODE_TITLE;
		}

		public override void OnInspectorGUI()
		{
			this.serializedObject.Update();
			EditorGUILayout.HelpBox(MSG, MessageType.None);
			this.serializedObject.ApplyModifiedProperties();
		}
		#endif
	}
}
