using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionEnabled : MonoBehaviour
{

    [SerializeField] GameObject angerLabel;
    [SerializeField] GameObject angerLabelUnknown;

    [SerializeField] GameObject loveLabel;
    [SerializeField] GameObject loveLabelUnknown;

    void Update() {
        if (StoryProgress.emotionAngerHidden == false) {
            angerLabel.SetActive(true);
            angerLabelUnknown.SetActive(false);
        } else {
            angerLabel.SetActive(false);
            angerLabelUnknown.SetActive(true);
        }

        if (StoryProgress.emotionLoveHidden == false) {
            loveLabel.SetActive(true);
            loveLabelUnknown.SetActive(false);
        } else {
            loveLabel.SetActive(false);
            loveLabelUnknown.SetActive(true);
        }
    }
}
