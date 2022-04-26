using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int _maxLevel;


    public void NextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex < _maxLevel - 1)
        {
            UnsubcribeBlenderEvents();
            Application.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            UnsubcribeBlenderEvents();
            Application.LoadLevel(0);
        }
    }
    private void UnsubcribeBlenderEvents()
    {
        FindObjectOfType<Blender>().UnsubscribeAllEvents();
        FindObjectOfType<Mixator>().UnsubscribeAllEvents();
        FindObjectOfType<UI>().UnsubscribeAllEvents();
    }
}
