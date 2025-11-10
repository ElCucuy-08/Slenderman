using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class New_Game : MonoBehaviour
{
    public void SceneLoad(int indexScene)
    {
        SceneManager.LoadScene(indexScene);
    }
}
