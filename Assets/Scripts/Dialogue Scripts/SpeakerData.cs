using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Speaker", menuName = "Dialogue/Speaker")]
public class SpeakerData : ScriptableObject
{
    public const string STATE_NEUTRAL = "neutral";
    public const string STATE_HAPPY = "happy";
    public const string STATE_ANGRY = "angry";
    public const string STATE_SAD = "sad";
    public const string STATE_SHOCKED = "shocked";
    public const string STATE_SMUG = "smug";
    public const string STATE_BASHFUL = "bashful";
    public const string STATE_SPECIAL1 = "special1";
    public const string STATE_SPECIAL2 = "special2";
    public const string STATE_SPECIAL3 = "special3";
    public const string STATE_SPECIAL4 = "special4";

    public string speakerName;
    public Sprite splashNeutral, splashHappy, splashAngry, splashSad, splashShocked, splashSmug, splashBashful, splashSpecial1, splashSpecial2, splashSpecial3, splashSpecial4;

    public Sprite GetStateSplash(string state)
    {
        switch (state)
        {
            default:
            case STATE_NEUTRAL: return splashNeutral;
            case STATE_HAPPY: return splashHappy;
            case STATE_ANGRY: return splashAngry;
            case STATE_SAD: return splashSad;
            case STATE_SHOCKED: return splashShocked;
            case STATE_SMUG: return splashSmug;
            case STATE_BASHFUL: return splashBashful;
            case STATE_SPECIAL1: return splashSpecial1;
            case STATE_SPECIAL2: return splashSpecial2;
            case STATE_SPECIAL3: return splashSpecial3;
            case STATE_SPECIAL4: return splashSpecial4;
        }
    }
}
