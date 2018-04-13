using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Player))]
public class PlayerEditor : Editor
{
	Player	player;

	private void OnEnable()
	{
		player = target as Player;
	}

	public override void OnInspectorGUI()
	{
		player.finishEuler = EditorGUILayout.Vector3Field("Finish Euler", player.finishEuler);
		player.tolerance = EditorGUILayout.FloatField("Tolerance", player.tolerance);

		player.constraintFoldout = EditorGUILayout.Foldout(player.constraintFoldout, "Constraints");
		if (player.constraintFoldout)
			using (new EditorGUILayout.HorizontalScope())
			{
				EditorGUIUtility.labelWidth = 20;
				player.lock_x = EditorGUILayout.Toggle("X", player.lock_x);
				player.lock_y = EditorGUILayout.Toggle("Y", player.lock_y);
				player.lock_z = EditorGUILayout.Toggle("Z", player.lock_z);
			}
		
	}
}
