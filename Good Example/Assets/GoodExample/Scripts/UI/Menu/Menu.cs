using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private const string BootstrapSceneName = "Bootstrap";

    [SerializeField] private Button _startButton;

    private void Start()
    {
        _startButton.onClick.AddListener(() =>
        {
            LoadScene(BootstrapSceneName);
        });
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
