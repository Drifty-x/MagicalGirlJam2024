using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmButton : MonoBehaviour
{
    [SerializeField]
    public KeyCode key;

    public bool createMode;
    public GameObject notePrefab;

    BoxCollider2D col;
    Scoreboard scoreboard;

    // Start is called before the first frame update
    void Start()
    {
        col = this.GetComponent<BoxCollider2D>();
        scoreboard = (Scoreboard)FindObjectOfType<Scoreboard>();
    }

    // Update is called once per frame
    void Update()
    {
        if (createMode)
        {
            if (Input.GetKeyDown(key))
            {
                GameObject n = Instantiate(notePrefab, transform.position, Quaternion.identity);
                n.transform.parent = transform;
            }
        }
        else
        {
            if (Input.GetKeyDown(key))
            {
                GameObject[] notes = GameObject.FindGameObjectsWithTag("Note");
                (GameObject closestNote, float distance) = FindClosestNoteUnderKey(notes);
                if (closestNote is not null)
                {
                    Debug.Log("Note should be destroyed");
                    scoreboard.IncreaseScore(distance);
                    Destroy(closestNote);
                }
            }
        }

    }

    // depending on spacing and sizing, we might have multiple notes under the key at once
    // so this is required to disambiguate them
    (GameObject, float) FindClosestNoteUnderKey(GameObject[] notes)
    {
        GameObject closest = null;
        float minDist = Mathf.Infinity;

        // find the closest note
        foreach (GameObject note in notes)
        {
            float noteDist = Vector2.Distance(note.GetComponent<Rigidbody2D>().position, col.transform.position);
            if (noteDist < minDist)
            {
                closest = note;
                minDist = noteDist;
            }
        }

        // if the closest note is not touching the collider, don't destroy
        // we assume it's impossible for note A to touch the collider while being farther than note B which does not touch the collider,
        // so don't make the bounding box weird asymmetrical shapes :p
        if (closest is null || !col.IsTouching(closest.GetComponent<Collider2D>()))
        {
            return (null, Mathf.Infinity);
        }

        return (closest, minDist);
    }
}
