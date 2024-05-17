using System.Collections;
using UnityEngine;

public class PlayerFlash : MonoBehaviour {
    [SerializeField]
    private SpriteRenderer sprite;

    [SerializeField]
    private Color flashColor;

    private void OnValidate() {
        if (!sprite) {
            sprite = GetComponent<SpriteRenderer>();
        }
    }

    public IEnumerator FlashPlayer(float flashTime) {
        Color originalColor = sprite.color;
        float elapsedTime = 0.0f;
        float elapsedFlashPercentage = 0.0f;
        float pingPongPercentage;

        while (elapsedTime < flashTime) {
            elapsedTime += Time.deltaTime;
            elapsedFlashPercentage = elapsedTime / flashTime;

            if (elapsedFlashPercentage > 1.0f) {
                elapsedFlashPercentage = 1.0f;
            }

            pingPongPercentage = Mathf.PingPong(elapsedFlashPercentage * 2 * 6, 1);
            sprite.color = Color.Lerp(originalColor, flashColor, pingPongPercentage);

            yield return null;
        }
    }
}