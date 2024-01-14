using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int level = 1;
    public static GameManager instance;

    void Start()
    {
        if (instance == null) instance = this;
    }

    void Update()
    {

    }

    public void ChangeLevel()
    {
        if (level != 2)
        {
            ++level;
            AudioManager.instance.PlayMusic($"Stage{level}");
            SCManager.instance.LoadScene($"Level{level}");
        }
        else
        {
            AudioManager.instance.PlayMusic("Win");
            SCManager.instance.LoadScene("Win");
        }
    }
}