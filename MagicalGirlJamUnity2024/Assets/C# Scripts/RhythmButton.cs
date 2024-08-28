using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmButton : MonoBehaviour
{
    [SerializeField]
    public KeyCode key;
    [SerializeField]
    bool active = false;
    [SerializeField]
    GameObject note;

    public bool createMode;
    public GameObject notePrefab;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (createMode)
        {
            if(Input.GetKeyDown(key))
            {
                GameObject n = Instantiate(notePrefab, transform.position, Quaternion.identity);
                n.transform.parent = transform;
            }
        }
        else
        {
            if (Input.GetKeyDown(key))
            {
                Debug.Log("Note should be destroyed");
                Destroy(note);
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        active = true;
        if (collision.tag == "Note")
        {
            note = collision.gameObject;
            Debug.Log(active);
            Debug.Log(note);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        active = false;
        Debug.Log("Note is not in range");
    }
}
