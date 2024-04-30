using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatch : MonoBehaviour
{
    [SerializeField] private GameObject other;
    private bool unlocked = false;

    //Action triggered by an interaction object - Opens the hatch for exit
    public void Action()
    {
        other.GetComponent<Animator>().SetBool("isUnlocked", true);
        GetComponent<Animator>().SetBool("isUnlocked", true);
        unlocked = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(unlocked && collision.gameObject.tag == "Player") GameObject.Find("Main Camera").GetComponent<LevelTransitions>().NextLevel();
    }
}
