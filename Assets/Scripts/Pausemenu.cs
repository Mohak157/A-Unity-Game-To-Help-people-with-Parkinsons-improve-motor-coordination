using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class Pausemenu : MonoBehaviour
{
    public GameObject pausepanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            pausepanel.SetActive(true);

            Time.timeScale = 0;
        }
    }

    public void Resume()
    {
        pausepanel.SetActive(false);
        Time.timeScale = 1;

    }

    public void goback()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(0);
    }
}
