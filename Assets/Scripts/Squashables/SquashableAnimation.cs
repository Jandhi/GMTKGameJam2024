using UnityEditor;
using UnityEngine;


public class SquashableAnimation : ScriptableObject
{
    public AnimationCurve Curve;

    [MenuItem("Assets/Create/SquashableAnimation")]
    public static void CreateSquashable()
    {
        SquashableAnimation asset = ScriptableObject.CreateInstance<SquashableAnimation>();

        AssetDatabase.CreateAsset(asset, "Assets/SquashableAnimation.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}