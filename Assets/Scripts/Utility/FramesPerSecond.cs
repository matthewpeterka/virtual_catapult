
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// to get information about game performance in FPS
/// </summary>
public class FramesPerSecond : MonoBehaviour
{
    private float elapsedTime;
    private float deltaTime;
    //
    [SerializeField] Text fpsText;
    [SerializeField] float waitTime;

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime < waitTime)
            return;

        elapsedTime = 0f;
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = Mathf.Ceil(fps).ToString();
    }
}
