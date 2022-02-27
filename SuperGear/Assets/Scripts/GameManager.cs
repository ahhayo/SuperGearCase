using Assets.Scripts;
using Assets.Scripts.CarParts;
using Assets.Scripts.UIInteractions;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public UIManager UIManager;
    public CameraController cameraController;
    public Car car;
    public Race Race;

    private void Awake()
    {
        if (!instance)
            instance = this;
        if (!car)
            car = FindObjectOfType<Car>();
    }
}
