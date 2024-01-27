using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject MainCanvas;
    [SerializeField] private GameObject CreditsCanvas;
    [SerializeField] private GameObject ConfigurationCanvas;
    private void Awake()
    {
        ShowMainCanvas();
    }
    public void StartGame()
    {
        //TODO Implement start game logic
    }
    public void ShowMainCanvas()
    {
        OpenCanvas(CanvasType.Main);
    }
    public void ShowCredits()
    {
        OpenCanvas(CanvasType.Credits);
    }
    public void ShowConfiguration()
    {
        OpenCanvas(CanvasType.Configuration);
    }
    public void QuitApplication()
    {
        Application.Quit();
    }
    public void OpenCanvas(CanvasType canvas)
    {
        MainCanvas.SetActive(canvas == CanvasType.Main);
        CreditsCanvas.SetActive(canvas == CanvasType.Credits);
        ConfigurationCanvas.SetActive(canvas == CanvasType.Configuration);
    }
}
public enum CanvasType
{
    Main = 1,
    Credits = 2,
    Configuration = 3
}