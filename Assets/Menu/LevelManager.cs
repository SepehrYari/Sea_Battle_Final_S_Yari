using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	public string sceneToLoad = "Game";

	public GameObject SeaMonster;
    

	public void LoadGame ()
	{
		SceneManager.LoadScene(sceneToLoad);
	}

    private void Update()
    {
        if (SeaMonster.activeSelf == false)
        {
            SceneManager.LoadScene("You Win!");
        }
    }
}
