using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Root
{
    public class UITweener : MonoBehaviour
    {
        public void StartGame(int num)
        {
            SceneManager.LoadSceneAsync(num);
        }

        public void SettingsGame()
        {
            Debug.Log("SETTINGS GAME LOAD");
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
