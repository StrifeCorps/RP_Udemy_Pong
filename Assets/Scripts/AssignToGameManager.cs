using UnityEngine;

public class AssignToGameManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        if (gameManager != null) 
        {  
            if(this.name.Contains("player1")) gameManager.player1ScoreText = this.gameObject.GetComponent<TMPro.TMP_Text>();
            else gameManager.player2ScoreText = this.gameObject.GetComponent<TMPro.TMP_Text>();
        }
    }
}
