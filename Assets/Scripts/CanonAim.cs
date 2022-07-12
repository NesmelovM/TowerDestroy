using UnityEngine;

public class CanonAim : MonoBehaviour
{
    [SerializeField] private GameObject _canonMuzzle;
    void Update()
    {
        LookAt();
    }

    void LookAt()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            Vector2 direction = (touchPosition - transform.position);
            _canonMuzzle.transform.right = direction;
        }
    }
}
