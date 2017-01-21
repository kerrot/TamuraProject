using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Galley : MonoBehaviour {
    [SerializeField]
    private GameObject[] pages;

    int now = 0;

    void Start()
    {
        if (pages.Length > 0)
        {
            now = 0;
            pages[0].SetActive(true);
        }
    }

    public void PageUp()
    {
        now += pages.Length + 1;
        ChangePage();
    }

    public void PageDown()
    {
        now += pages.Length - 1;
        ChangePage();
    }

    void ChangePage()
    {
        now %= pages.Length;

        pages.ToList().ForEach(p => p.SetActive(false));
        pages[now].SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
