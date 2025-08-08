using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
	GameManager instance;
    [SerializeField] TMP_Text player1ScoreText;
	[SerializeField] TMP_Text player2ScoreText;
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

	void Start()
	{
		UpdateScore(0, 0);
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.R)) { UpdateScore(1, 1); }
	}

	public void UpdateScore(int _player1Score, int _player2Score)
	{
		player1Score += _player1Score;
		player2Score += _player2Score;
		player1ScoreText.text = player1Score.ToString();
		player2ScoreText.text = player2Score.ToString();
	}
}
