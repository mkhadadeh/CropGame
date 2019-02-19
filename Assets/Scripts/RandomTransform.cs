using UnityEngine;
using UnityEditor;
using System.Collections;
// CopyComponents - by Michael L. Croswell for Colorado Game Coders, LLC
// March 2010

public class RandomTransform : ScriptableWizard
{
    public bool copyValues = true;
    public GameObject Parent;

    [MenuItem("Custom/Random Transform")]


    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard("You Spin Me Right Round", typeof(RandomTransform), "You Spin Me Right Round");
    }

    void OnWizardCreate()
    {
        Transform[] Items;
        Items = Parent.GetComponentsInChildren<Transform>();

        foreach (Transform t in Items)
        {
            t.rotation = Quaternion.Euler(new Vector3(t.rotation.x, Random.Range(0f,360f), t.rotation.z));
            t.localScale = t.localScale * Random.Range(0.8f, 1.5f);
        }

    }
}