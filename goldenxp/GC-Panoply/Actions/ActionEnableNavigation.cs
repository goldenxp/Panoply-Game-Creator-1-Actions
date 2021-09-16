namespace GameCreator.Core
{
	using UnityEngine;
	using Opertoon.Panoply;
	
	#if UNITY_EDITOR
	using UnityEditor;
	#endif

	public class ActionEnableNavigation : IAction
	{
		public bool enableKeyboard = true;
		public bool enablePassiveInput = true;
		
		public override bool InstantExecute(GameObject target, IAction[] actions, int index)
        {
	        if (PanoplyCore.scene != null) 
	        {
	        	PanoplyCore.scene.disableNavigation = false;
	        	PanoplyController controller = PanoplyCore.scene.GetComponent<PanoplyController>();
	        	if (controller)
	        	{
	        		controller.keyboardInput = enableKeyboard;
	        		controller.passiveInput = enableKeyboard;
	        	}
	        }
		        
		    return true;
        }

		#if UNITY_EDITOR
		public static new string NAME = "Panoply/Enable Navigation";
		private const string NODE_TITLE = "Enable Navigation";
		public override string GetNodeTitle()
		{
			return NODE_TITLE;
		}
		#endif
	}
}
