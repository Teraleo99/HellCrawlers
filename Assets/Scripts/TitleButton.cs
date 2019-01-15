using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{

    public void GoToTitle()
    {
        //when dead, click button to return to title
        SceneManager.LoadScene("Title");
    }

}
