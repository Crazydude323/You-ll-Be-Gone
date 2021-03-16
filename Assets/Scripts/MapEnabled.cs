using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEnabled : MonoBehaviour
{
    public static bool mapAlleyHidden = true;

    [SerializeField] GameObject alley;

    void Start() {
        alley.SetActive(!StoryProgress.mapAlleyHidden);
    }

}