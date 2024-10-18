using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDance : MonoBehaviour
{
    public string hitGrade; //pass into dict

    public GameObject characterMesh; //use dancing char -- determines how dict is created

    Dictionary<string, List<int>> pose_Dict = new();
// <'hitGrade', [left, right, up, down]>        valList = blend pose index --- index of valList = danceDirection
    string characterName;
    int blendShapeCount;
    int currentBlend;    
    SkinnedMeshRenderer skinnedMeshRenderer;
    Mesh skinnedMesh;

    void Awake ()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer> ();
        skinnedMesh = GetComponent<SkinnedMeshRenderer> ().sharedMesh;
        characterName = characterMesh.name;
        initializePoseDict();
    }

    void Start ()
    {
        blendShapeCount = skinnedMesh.blendShapeCount;
        skinnedMeshRenderer.SetBlendShapeWeight (0, 100);
        currentBlend = 0;
    }


    public void currentKeyDown(KeyCode hitKey)
    {
        if (hitGrade == "")
        {
            hitGrade = "GOOD";
        }

    //get hitGrade from Scoreboard/Rhythym button scripts, pass to dict as key, get blendshape Index based on direction
    // Direction index: Left = 0, Right = 1, Up = 2, Down = 3
        if (hitKey == KeyCode.LeftArrow)    // 0
        {
            changePose(pose_Dict[hitGrade][0]);
        }

        else if (hitKey == KeyCode.RightArrow)   // 1
        {
            changePose(pose_Dict[hitGrade][1]);
        }

        else if (hitKey == KeyCode.UpArrow)      // 2
        {
            changePose(pose_Dict[hitGrade][2]);
        }

        else if (hitKey == KeyCode.DownArrow)    // 3
        {
            changePose(pose_Dict[hitGrade][3]);
        }
    }

    public void changePose(int blendID)
    {
        skinnedMeshRenderer.SetBlendShapeWeight (currentBlend, 0);
        skinnedMeshRenderer.SetBlendShapeWeight (blendID, 100);
        currentBlend = blendID;
    }

    public void initializePoseDict()
    {
    // Cockroach        
        if (characterName == "GEO_Roach");
        {
            pose_Dict.Add("PERFECT", new List<int> {11, 4, 5, 2});
            pose_Dict.Add("GREAT", new List<int> {10, 3, 1, 2});
            pose_Dict.Add("GOOD", new List<int> {10, 3, 1, 2});
            pose_Dict.Add("BAD", new List<int> {10, 3, 1, 2});
            pose_Dict.Add("MISS", new List<int> {7, 6, 9, 8});
        }

    // MagicalGirl
        //if (characterName == magicRoach);
        {
            //pose_Dict.Add("PERFECT", new List<int> {});
            //pose_Dict.Add("GREAT", new List<int> {});
            //pose_Dict.Add("GOOD", new List<int> {});
            //pose_Dict.Add("BAD", new List<int> {});
            //pose_Dict.Add("MISS", new List<int> {});
        }
    }
}