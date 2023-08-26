using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private float _speed;

    private RawImage _image;
    private float _imageUVPositionX;

    private void Start()
    {
        _image = GetComponent<RawImage>();
        Debug.Log(_image.name);
    }

    private void Update()
    {
        _imageUVPositionX += _speed * Time.deltaTime;
        _image.uvRect = new Rect(
            _imageUVPositionX,
            _image.uvRect.y,
            _image.uvRect.width,
            _image.uvRect.height);

        Debug.Log(_imageUVPositionX);
    }
}
