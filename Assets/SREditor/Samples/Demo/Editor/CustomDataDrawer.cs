using Demo;
using SerializeReferenceEditor.Editor;
using UnityEditor;
using UnityEngine;

namespace Demo.Editor
{
	[CustomPropertyDrawer(typeof(CustomData), false)]
	public class CustomDataDrawer : PropertyDrawer
	{
		private SRDrawer _drawer = new();
		
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			//EditorGUI.BeginProperty(position, label, property);
			
			var dataProperty = property.FindPropertyRelative("Data");
			_drawer.Draw(position, dataProperty, label);
			
			//EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			var dataProperty = property.FindPropertyRelative("Data");
			return _drawer.GetPropertyHeight(dataProperty, label);
		}
	}
}