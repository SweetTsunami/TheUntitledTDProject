//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;

//[CustomEditor(typeof(AttackerSpawnTemplate_SO))]
//public class WaveInspector : Editor
//{
//    AttackerSpawnTemplate_SO template;
//    void OnEnable()
//    {
//        template = (AttackerSpawnTemplate_SO)target;
//    }

//    public override void OnInspectorGUI()
//    {
//        EditorGUILayout.LabelField("Total number of waves", template.waveSetup.Count.ToString());
//        // EditorGUILayout.LabelField("Total number of attackers", attackerSpawnTemplate_SO.waveSetup);
//        if (GUILayout.Button("Add Wave"))
//        {
//            AddWave();
//        }

//        if (GUILayout.Button("Remove last Wave"))
//        {
//            RemoveLastWave();
//        }

//        for (int i = 0; i < template.waveSetup.Count; i++)
//        {
//            GUILayout.BeginHorizontal();
//            GUILayout.TextField("Wave size: " + template.waveSetup[i].attackerSetup.Count, GUILayout.Width(100));
//            GUILayout.EndHorizontal();
//        }

//        GUILayout.Space(20);
//        base.OnInspectorGUI();

//    }

//    void AddWave()
//    {
//        template.waveSetup.Add(new AttackerSpawnTemplate_SO.WaveSetup());
//    }

//    void RemoveLastWave()
//    {
//        template.waveSetup.Remove(template.waveSetup[template.waveSetup.Count - 1]);
//    }
//}
