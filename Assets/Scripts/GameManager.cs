using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public GameManager instance;
    public TMP_Text player1ScoreText;
	public TMP_Text player2ScoreText;
	[SerializeField] int player1Score = 0;
	[SerializeField] int player2Score = 0;

	private void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	public void UpdateScore(int _player1Score, int _player2Score)
	{
		player1Score += _player1Score;
		player2Score += _player2Score;
		player1ScoreText.text = player1Score.ToString();
		player2ScoreText.text = player2Score.ToString();
	}

	public void LoadGameScene()
	{
		SceneManager.LoadScene(1);
	}
}
