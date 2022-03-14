namespace Assets.Scripts.Utilities
{
    public class RPMTextColorChanger : TextColorChanger
    {

        public override void Start()
        {
            base.Start();
            maxVal = GameManager.instance.car.CarTemplate.MaxRPM;
        }

        public override void Update()
        {
            base.Update();
            minVal = GameManager.instance.car.CurrentRPM;
        }
    }
}
