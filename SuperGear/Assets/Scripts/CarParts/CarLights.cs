using Assets.Scripts.CarParts;
using UnityEngine;

public class CarLights : MonoBehaviour
{
    public Car Car;
    public GameObject[] FrontLights;
    public GameObject[] BrakeLights;

    private bool lightsOff = false;
    private void Start()
    {
        if (!Car)
            Car = GetComponent<Car>();

        GameManager.instance.UIManager.CarLightsButton.onClick.AddListener(ChangeFrontLightStatus);
    }

    private void TurnOnBrakeLights(bool isBraking)
    {
        foreach (var light in BrakeLights)
            light.gameObject.SetActive(isBraking);
    }

    private void ChangeFrontLightStatus()
    {
        foreach (var light in FrontLights)
            light.gameObject.SetActive(!light.activeSelf);
        lightsOff = !lightsOff;

        GameManager.instance.UIManager.CarLightsButton.image.color = lightsOff ? Color.black : Color.white;
    }

    private void Update()
    {
        TurnOnBrakeLights(Car.UsingBrake);
        if (Input.GetKeyDown(KeyCode.L))
            ChangeFrontLightStatus();
    }

    private void OnDestroy()
    {
        GameManager.instance.UIManager.CarLightsButton.onClick.RemoveListener(ChangeFrontLightStatus);
    }
}
