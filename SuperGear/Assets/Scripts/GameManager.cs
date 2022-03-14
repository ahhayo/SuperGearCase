using Assets.Scripts;
using Assets.Scripts.CarParts;
using Assets.Scripts.UIInteractions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public UIManager UIManager;
    public CameraController cameraController;
    public Car car;//current car.
    public Race Race;
    public PlayfabManager PlayfabManager;



    private void Awake()
    {
        if (!instance)
            instance = this;
        if (!car)
            car = FindObjectOfType<Car>();
        if (!PlayfabManager)
            PlayfabManager = FindObjectOfType<PlayfabManager>();
    }


    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
