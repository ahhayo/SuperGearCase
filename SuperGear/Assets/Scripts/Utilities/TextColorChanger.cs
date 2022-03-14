using TMPro;
using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class TextColorChanger : MonoBehaviour
    {
        public float minVal;
        public float maxVal;
        public TextMeshProUGUI textToChange;
        public Color targetColor;
        private Color startColor;

        private void Awake()
        {
            if (!textToChange)
                textToChange = GetComponent<TextMeshProUGUI>();
            startColor = textToChange.color;
        }
        public virtual void Start()
        {

        }
        public void ChangeTextColor(float limitMin, float limitMax, TextMeshProUGUI textToChange, Color targetColor)
        {
            var val =  (minVal / maxVal);
            var targetEstimation = new Color(targetColor.r * val, targetColor.g * val, targetColor.b * val, 1);
            textToChange.color = Color.Lerp(textToChange.color, targetEstimation, Time.deltaTime * 2);
        }

        public virtual void Update()
        {
        }
        private void FixedUpdate()
        {
            ChangeTextColor(minVal, maxVal, textToChange, targetColor);
        }
    }
}
