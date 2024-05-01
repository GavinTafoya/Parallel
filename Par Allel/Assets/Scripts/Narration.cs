using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Narration : MonoBehaviour
{
    private string[] narrationIDs = 
    { 
        "1", "2", "3", "atrium2", "4", "5", "6", "7", "8", "9", "boss2", "boss3", "10"
    };
    private string[] narrations = 
    {
        "We decided the best thing to do was to try and escape the ship.",
        "At that point, we were wondering why the facility was on lockdown.",
        "Oh - that's why...",
        "That was definitely spooky, luckily we were at a safe distance.",
        "The beds kept coming in and out of the walls, perfect for climbing out of there.",
        "The power went out in the next room, we had to find our way in the dark.",
        "The syringges, they're in the walls!",
        "We took a detour through the maintenance shaft, thinking it would be a shorter path.",
        "We finally made it to the Command Center.",
        "Some of the ghosts must've caused an electrical outage, too.",
        "That ghost was huge!",
        "He must have been the one in charge, we had to take him down!",
        "Finally! We were able to find the escape pods.",
    };
    [SerializeField] private AudioClip[] audios;

    [SerializeField] private AudioSource source;
    private TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
        text.color = new Color(1, 1, 1, 0);
    }

    public void DisplayNarration(string id)
    {
        int d = 0;
        for (int i = 0; i < narrationIDs.Length; i++)
        {
            if (id.Equals(narrationIDs[i]))
            {
                d = i;
                break;
            }
        }

        text.text = narrations[d];
        source.clip = audios[d];
        source.Play();
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {

        while (text.color.a < 1)
        {
            text.color = new Color(1, 1, 1, text.color.a + 0.06f);
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForSeconds(8f);
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        while (text.color.a > 0)
        {
            text.color = new Color(1, 1, 1, text.color.a - 0.06f);
            yield return new WaitForFixedUpdate();
        }
    }
}
