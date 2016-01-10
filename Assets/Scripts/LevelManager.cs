using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name){
        Brick.breakableCount = 0;
        SceneManager.LoadScene(name);
	}

	public void QuitRequest(){
		Application.Quit();
	}

    public void LoadNextLevel() {
        Brick.breakableCount = 0;
        Scene currScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currScene.buildIndex + 1);
    }

    public void BrickDestroyed() {
        if(Brick.breakableCount <= 0) {
            LoadNextLevel();
        }
    }
}
