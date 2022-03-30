using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerScript : MonoBehaviour {

    public void loadLevelFunction(string name)
    {
        Application.LoadLevel(name);
    }

    public void QuitGameFunction()
    {
        Application.Quit();
    }

}
