using UnityEngine;
using UnityEngine.UI;

public class MouseFollower : MonoBehaviour {
	[SerializeField] Image image;
	public static void SetImage(Sprite sprite) {
		instance.image.sprite = sprite;
		instance.image.enabled = sprite != null;
	}

    static MouseFollower instance { get; set; }
	void Awake() => instance = this;

	void Update() {
        if (image.sprite == null) { return; }
		if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) { SetImage(null); }

        Vector3 targetPos = Input.mousePosition;
        transform.position = targetPos;
    }
}