using UnityEngine;
using UnityEngine.UI;


public class ImageFiller : MonoBehaviour
{
    [SerializeField] private Image _currentImage;

    public void UpdateViewCurrentCount(int currentImage, int maxImageValue)
    {
        _currentImage.fillAmount = currentImage / (float)maxImageValue;
    }
}

