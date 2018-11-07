using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;

[CustomEditor(typeof(TimelineApply))]
public class TimelineApplyInspector : Editor
{
    public override void OnInspectorGUI()
    {
        var t = (TimelineApply)target;
        GUILayout.BeginVertical();
        for (int i = 0; i < t.Playables.Count; i++)
        {
            GUILayout.BeginHorizontal();
            var obj = EditorGUILayout.ObjectField(t.Playables[i], typeof(PlayableDirector), true);
            t.Playables[i] = (PlayableDirector)obj;
            var obj2 = EditorGUILayout.ObjectField(t.Timelines[i], typeof(PlayableAsset), false);
            t.Timelines[i] = (PlayableAsset)obj2;
            t.Offsets[i] = EditorGUILayout.FloatField(t.Offsets[i]);
            if (GUILayout.Button("-"))
            {
                t.Playables.RemoveAt(i);
                t.Timelines.RemoveAt(i);
                t.Offsets.RemoveAt(i);
            }
            GUILayout.EndHorizontal();
        }
        GUILayout.EndVertical();
        if (GUILayout.Button("+"))
        {
            t.Playables.Add(default(PlayableDirector));
            t.Timelines.Add(default(PlayableAsset));
            t.Offsets.Add(0);
        }
    }
}
