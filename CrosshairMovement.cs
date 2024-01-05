using UnityEngine;
using UnityEngine.UI;

public class CrosshairMovement : MonoBehaviour
{
    [SerializeField] private PlayerMovement _gun = null;
    [SerializeField] private Image _crosshair = null;
    private RectTransform _canvasRT;
    private float _canvasHeight, _canvasWidth;

    void Awake()
    {
        _canvasRT = GetComponent<RectTransform>();
        _canvasHeight = _canvasRT.rect.height;
        _canvasWidth = _canvasRT.rect.width;
    }

    void Update()
    {
        Vector2 position = _crosshair.rectTransform.anchoredPosition;

        position.x = _canvasWidth * ((_gun.transform.position.x - _gun.xMin) / (_gun.xMax - _gun.xMin)) - _canvasWidth/2;
        position.y = _canvasHeight * ((_gun.transform.position.y - _gun.yMin) / (_gun.yMax - _gun.yMin)) - _canvasHeight / 2;

        _crosshair.rectTransform.anchoredPosition = position;
    }
}
