using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    public int score;
    [SerializeField]
    int maxScorePerNote = 1000;
    [SerializeField]
    float victoryScoreThresholdPercentage = 0.5f;
    [SerializeField]
    int victoryScoreThreshold;

    public Slider slider;
    public TMP_Text textComp;

    string scoreFString;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;

        slider = this.GetComponent<Slider>();
        slider.maxValue = maxScorePerNote * GameObject.FindGameObjectsWithTag("Note").Length; // perfect score on every note
        victoryScoreThreshold = (int) Mathf.Round(victoryScoreThresholdPercentage * slider.maxValue); // X% of the max possible score, round up if appropriate

        textComp = this.GetComponentInChildren<TMP_Text>();
        scoreFString = "D" + ((int)Mathf.Floor(Mathf.Log(slider.maxValue, 10)) + 1).ToString();
        textComp.text = 0.ToString(scoreFString); // fill out the score with 0s = # of digits in maxscore
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore(float distance)
    {
        distance = Mathf.Abs(distance);

        // todo misses are not handled here, because the function is only called when a note is hit. misses should be handled in the button or note script
        // todo health is not handled here. this is a score only class. healthbar UpdateHealth() can be called before UpdateUI() here though

        // hardcoded category thresholds because I'm lazy. playtest and fine tune these
        if (distance <= 5) // perfect
        {
            score += maxScorePerNote;
            // todo in each of these spawn appropriate gui vfx that says "perfect!" or "bad" or w/e
        }
        else if (distance <= 25) // Great
        {
            score += (int) Mathf.Round(0.6f * maxScorePerNote);
        }
        else if (distance <= 60) // Good
        {
            score += (int)Mathf.Round(0.4f * maxScorePerNote);
        }
        else // Bad
        {
            score += (int)Mathf.Round(0.15f * maxScorePerNote);
        }

        Debug.Log(score);

        UpdateUI();
    }

    void UpdateUI()
    {
        slider.value = score;
        textComp.text = score.ToString(scoreFString);
    }
}
