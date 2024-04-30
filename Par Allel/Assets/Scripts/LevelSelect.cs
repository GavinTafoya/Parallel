using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private GameObject[] pages, levels;
    private int pageNumber;

    private void Start()
    {
        pageNumber = 1;
        int i = 0;
        foreach(GameObject level in levels)
        {
            i++;
            if (PlayerPrefs.GetFloat("highLevel", 2) < i + 1)
            {
                level.GetComponent<Button>().enabled = false;
                level.GetComponent<Image>().color = new Color(level.GetComponent<Image>().color.r * .5f, level.GetComponent<Image>().color.g * .5f, level.GetComponent<Image>().color.b * .5f);
            }
        }
    }

    public void PageLeft()
    {
        if (pageNumber == 1) LoadLevel(0);
        pageNumber++;
        foreach (GameObject page in pages) page.GetComponent<RectTransform>().localPosition += new Vector3(2000, 0, 0);
    }

    public void PageRight()
    {
        if (pageNumber == 3) return;
        pageNumber--;
        foreach (GameObject page in pages) page.GetComponent<RectTransform>().localPosition -= new Vector3(2000, 0, 0);
    }

    public void LoadLevel(int levelNum)
    {
        GameObject.Find("Main Camera").GetComponent<LevelTransitions>().LoadLevel(levelNum);
    }
}
