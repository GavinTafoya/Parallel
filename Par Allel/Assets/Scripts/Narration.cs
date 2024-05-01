using System;
using System.Collections;
using TMPro;
using UnityEngine;

[Serializable]
public struct PseudoArray<T>
{
    public T[] array;
}

public class Narration : MonoBehaviour
{
    [SerializeField] private PseudoArray<string>[] narrations;
    [SerializeField] private PseudoArray<AudioClip>[] audios;
    [SerializeField] private AudioSource source;
    private TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
        text.color = new Color(1, 1, 1, 0);
    }

    public void DisplayNarration(int num)
    {
        foreach(AudioClip a in audios[num].array)
        {
            text.text = narrations[num].array[0];
            source.clip = a;
            source.Play();
        }
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
