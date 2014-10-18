using UnityEngine;
using System.Collections;

namespace ProgressBar
{
    public class ProgressBar : MonoBehaviour
    {
        private GameObject indicator;

        const float deltaX = 0.1f;
        private float startX, endX;
        /*private*/ public int flinchCounter = 0;
        /*private*/ public int blinkCounter = 0;

        // Use this for initialization
        void Start()
        {
            indicator = transform.GetChild(0).gameObject;

            useGUILayout = true;

            guiTexture.pixelInset = new Rect {
                x = Screen.width * (1 / 20f),
                y = Screen.height * (1 / 20f),
                width = Screen.width * (18 / 20f),
                height = Screen.width * (1 / 40f)
            };

            indicator.guiTexture.pixelInset = new Rect {
                x = Screen.width * (1 / 20f),
                y = Screen.height * (1 / 20f),
                width = Screen.width * (1 / 20f),
                height = Screen.width * (1 / 40f)
            };

            startX = guiTexture.pixelInset.x;
            endX = guiTexture.pixelInset.width - indicator.guiTexture.pixelInset.width;
        }

        public void Hit(int power)
        {
            flinchCounter = 10 * power;
            blinkCounter = power * 4;
        }

        // Update is called once per frame
        void Update()
        {
            var inset = indicator.guiTexture.pixelInset;
            if (flinchCounter > 0) {
                flinchCounter--;
                inset.x = Mathf.Max(startX, inset.x - 2*deltaX);
            } else {
                inset.x = Mathf.Min(endX, inset.x + 2*deltaX);
            }
            if (blinkCounter > 0) {
                switch (blinkCounter % 24) {
                    case 23:
                        indicator.guiTexture.color = Color.red;
                        break;
                    case 11:
                        indicator.guiTexture.color = Color.white;
                        break;
                }
                blinkCounter--;
            }
            indicator.guiTexture.pixelInset = inset;
        }
    }
}


