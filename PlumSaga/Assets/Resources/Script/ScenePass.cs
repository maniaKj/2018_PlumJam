using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScenePass : MonoBehaviour {

    [SerializeField]
    private string m_TargetSceneName;

    [SerializeField]
    private Image m_FadeImage;

    private float m_FadeAlpha = 1.0f;

	void Update () {
        if(m_FadeAlpha > 0.0f)
        {
            m_FadeAlpha -= 0.1f;
            m_FadeImage.color = new Color(0, 0, 0, m_FadeAlpha);
        }
	}

    public void StartGame ()
    {
        SceneManager.LoadScene(m_TargetSceneName);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
