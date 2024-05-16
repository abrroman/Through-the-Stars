using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour {
    [SerializeField]
    private PlayerHpController playerHpController;

    [SerializeField]
    private CanvasGroup canvasGroup;

    private const float TIME_TO_DISSAPEAR = 1.0f;

    private void OnValidate() {
        if (!canvasGroup) {
            canvasGroup = GetComponentInParent<CanvasGroup>();
        }
    }

    private void OnEnable() {
        playerHpController.DamageTaken += OnDamageTaken;
    }

    private void OnDisable() {
        playerHpController.DamageTaken -= OnDamageTaken;
    }

    private void OnDamageTaken() {
        ChangeHealthBar();
        StartCoroutine(ShowHealthBar());
    }

    public void ChangeHealthBar() {
        GetComponent<Slider>().value = (float)playerHpController.Hp / PlayerHpController.MAX_HP;
    }

    private IEnumerator ShowHealthBar() {
        while (canvasGroup.alpha < 1.0f) {
            canvasGroup.alpha += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(TIME_TO_DISSAPEAR);

        while (canvasGroup.alpha > 0.0f) {
            canvasGroup.alpha -= Time.deltaTime;
            yield return null;
        }
    }
}