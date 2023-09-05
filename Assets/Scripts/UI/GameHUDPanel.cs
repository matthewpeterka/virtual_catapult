using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameHUDPanel : MonoBehaviour
{

    public static GameHUDPanel Instance { private set; get; }

    //
    [SerializeField] TextMeshProUGUI ballDistanceText;
    //

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateBallDistanceText(float distance)
    {
        ballDistanceText.text = distance.ToString("F1");
    }

    public void OnFireBallButtonClick()
    {
        VirtualCatapultController.Instance.CalculateBallDistance();
        UpdateBallDistanceText(VirtualCatapultController.Instance.BallDistance);
    }

    public void OnFireAgainButtonClick()
    {
        SceneManager.LoadScene(GameConstants.GAMEPLAY_SCENE);
    }


}
