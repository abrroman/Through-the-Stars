using UnityEngine;

public class ExplosionController : MonoBehaviour {
    public GameObject[] removeParts;

    public ExplosionController[] childrenExplosion;

    private Animator _animator;

    void Start() {
        _animator = GetComponent<Animator>();
    }

    public void DestroyPart(int index) {
        if (removeParts != null && index >= 0 && index < removeParts.Length)
            Destroy(removeParts[index]);
        else
            Debug.LogWarning("Index is out of range in DestroPart. index: " + index);
    }

    public void StartExplosion() {
        if (_animator == null)
            _animator = GetComponent<Animator>();
        _animator.SetBool("expl", true);
    }

    public void DestroyObject() {
        Destroy(gameObject);
    }

    public void DestroyChildren() {
        if (removeParts != null && removeParts.Length > 0)
            foreach (GameObject child in removeParts)
                Destroy(child);
    }
}