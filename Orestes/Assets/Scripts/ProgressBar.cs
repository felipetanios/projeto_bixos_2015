using UnityEngine;
using System.Collections;

namespace ProgressBar
{
    public class ProgressBar : MonoBehaviour
    {
        private GameObject indicator;

        public delegate void OnComplete();

        public OnComplete Complete;

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
            if (flinchCounter == 0 &&  blinkCounter == 0) {
                flinchCounter = 10 * power;
                blinkCounter = power * 8;
            } else {
                // Já foi atingido, aumentar ligeiramente o tempo apenas
                flinchCounter += power;
                blinkCounter += power / 2;
            }
        }

        // Update is called once per frame
        void Update()
        {
            var inset = indicator.guiTexture.pixelInset;

            if (flinchCounter > 0) {
                inset.x = Mathf.Max(startX, inset.x - 2*deltaX);

                flinchCounter--;
                if (inset.x == startX)
                    flinchCounter = 0;
            } else {
                inset.x = Mathf.Min(endX, inset.x + 2*deltaX);
            }

            if (blinkCounter > 0) {
                if (blinkCounter % 24 < 12)
                    indicator.guiTexture.color = Color.white;
                else
                    indicator.guiTexture.color = Color.red;
                blinkCounter--;
            }

            indicator.guiTexture.pixelInset = inset;

            if (inset.x == endX) {
                /* Fim da execução */
                enabled = false;
                Complete();
            }

            // Teste:
            //if (Random.value < .001f)
            //    Hit((int) (10 * Random.value));
        }
    }
}
