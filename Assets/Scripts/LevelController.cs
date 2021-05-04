using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public GameObject startPanel, endPanel;

    private Cloud[] clouds;

    private void OnEnable()
    {
        clouds = FindObjectsOfType<Cloud>();

        startPanel.SetActive(true);
        endPanel.SetActive(false);
    }

    public void StartButton() 
    {
        startPanel.SetActive(false);
    }

    public void EndButton()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (EveryoneIsHappy())
        {
            endPanel.SetActive(true);
        }
    }

    private bool EveryoneIsHappy()
    {
        foreach (var cloud in clouds)
        {
            if (!cloud.isHappy)
            {
                return false;
            }
        }

        return true;
    }
}
