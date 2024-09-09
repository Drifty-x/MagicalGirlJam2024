using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CockroachDance : MonoBehaviour
{
    int blendShapeCount;
    int currentBlend;    
    SkinnedMeshRenderer skinnedMeshRenderer;
    Mesh skinnedMesh;

    void Awake ()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer> ();
        skinnedMesh = GetComponent<SkinnedMeshRenderer> ().sharedMesh;
    }

    void Start ()
    {
        blendShapeCount = skinnedMesh.blendShapeCount;
        skinnedMeshRenderer.SetBlendShapeWeight (0, 100);
        currentBlend = 0;
    }

    void Update ()      //eventually change to check for miss/perfect/else, associates blends
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {
        changePose(1);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
        changePose(2);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
        changePose(10);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
        changePose(3);
        }
            
    }

    public void changePose(int blendID)
    {
        skinnedMeshRenderer.SetBlendShapeWeight (currentBlend, 0);
        skinnedMeshRenderer.SetBlendShapeWeight (blendID, 100);
        currentBlend = blendID;
    }
}
