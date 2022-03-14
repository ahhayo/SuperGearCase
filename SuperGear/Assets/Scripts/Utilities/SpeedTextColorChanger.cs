namespace Assets.Scripts.Utilities
{
    public class SpeedTextColorChanger : TextColorChanger
    {
        public override void Start()
        {
            base.Start();
            maxVal = GameManager.instance.car.CarTemplate.MaxSpeed;
        }

        public override void Update()
        {
            base.Update();
            minVal = GameManager.instance.car.CurrentSpeed;
        }

    }
}
