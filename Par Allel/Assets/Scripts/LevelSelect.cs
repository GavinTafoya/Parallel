using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private GameObject[] pages;
    private int pageNumber;

    private void Start()
    {
        pageNumber = 1;
    }

    public void PageLeft()
    {
        if (pageNumber == 1) return;
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
