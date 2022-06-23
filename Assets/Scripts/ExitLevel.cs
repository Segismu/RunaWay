using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
[SerializeField] float levelLoadDelay = 1f;
void OnTriggerEnter2D(Collider2D other)
{
    if (other.tag == "Player")
    {
         StartCoroutine(LoadNextStage());
    }
   
}

    IEnumerator LoadNextStage()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        FindObjectOfType<LevelPersist>().ResetLevelPersist();
        SceneManager.LoadScene(nextSceneIndex);
    }
}