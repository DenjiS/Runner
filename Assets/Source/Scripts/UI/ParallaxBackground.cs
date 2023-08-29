using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private float _speed;

    private RawImage _image;
    private float _imageUVPositionX;

    private void Awake()
    {
        _image = GetComponent<RawImage>();
    }

    private void Update()
    {
        _imageUVPositionX += _speed * Time.deltaTime;
        _image.uvRect = new Rect(
            _imageUVPositionX,
            _image.uvRect.y,
            _image.uvRect.width,
            _image.uvRect.height);
    }
}
