using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBootstrap : MonoBehaviour
{
    private const string PlayerSceneName = "Player";

    private IEnumerator Start()
    {
        float exampleTime = 3f;

        while (exampleTime > 0)
        {
            exampleTime -= Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene(PlayerSceneName);
    }
}
