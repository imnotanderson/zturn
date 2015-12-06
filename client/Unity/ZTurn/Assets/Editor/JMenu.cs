using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;


public class JMenu : EditorWindow {

	[UnityEditor.MenuItem("JMenu/Open")]
    static void Open(){
		EditorWindow.CreateInstance<JMenu>().Show();
	}

	void OnGUI(){
		if (GUILayout.Button ("Test")) {

		}
	}

}
