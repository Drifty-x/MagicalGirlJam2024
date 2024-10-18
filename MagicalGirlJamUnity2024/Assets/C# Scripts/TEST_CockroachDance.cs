using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//BASIC POSE CHANGE TESTING
public class CockroachDance : MonoBehaviour
{

    string characterName;
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
        //get pose variable from Scoreboard script, pass to 
        if (Input.GetKey(KeyCode.LeftArrow))    // 0
        {
            changePose(10);
        }

        if (Input.GetKey(KeyCode.RightArrow))   // 1
        {
            changePose(3);
        }

        if (Input.GetKey(KeyCode.UpArrow))      // 2
        {
            changePose(1);
        }

        if (Input.GetKey(KeyCode.DownArrow))    // 3
        {
            changePose(2);
        }

    }

    public void changePose(int blendID)
    {
        skinnedMeshRenderer.SetBlendShapeWeight (currentBlend, 0);
        skinnedMeshRenderer.SetBlendShapeWeight (blendID, 100);
        currentBlend = blendID;
    }


}
