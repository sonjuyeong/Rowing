using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mode : MonoBehaviour
{
    public void SceneChange_single()
    {
        SceneManager.LoadScene("E_start");
         
    }

    public void SceneChange_multi()
    {
        SceneManager.LoadScene("GameRoom");

    }
}
