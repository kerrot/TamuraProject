using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour {
    [SerializeField]
    private GameObject menu;
    [SerializeField]
    private GameObject galley1;
    [SerializeField]
    private GameObject galley2;

    public void GamePause()
    {
        Time.timeScale = 0;
        menu.SetActive(true);
    }

    public void ReturnGame()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
    }

    public void ShowObject(GameObject obj)
    {
        if (obj)
        {
            obj.SetActive(true);
        }
    }

    void OnDestroy()
    {
        Time.timeScale = 1;
    }
}
