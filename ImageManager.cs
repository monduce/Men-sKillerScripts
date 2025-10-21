using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NovelGame
{
    public class ImageManager : MonoBehaviour
    {
        [SerializeField] Sprite _background1;
        [SerializeField] Sprite _background2;
        [SerializeField] Sprite _eventCG1;
        [SerializeField] Sprite _eventCG2;
        [SerializeField] Sprite _eventCG3;
        [SerializeField] Sprite _eventCG4;
        [SerializeField] Sprite _eventCG5;
        [SerializeField] GameObject _backgroundObject;
        [SerializeField] GameObject _eventObject;
        [SerializeField] GameObject _imagePrefab;

        Dictionary<string, Sprite> _textToSprite;
        Dictionary<string, GameObject> _textToParentObject;

        Dictionary<string, GameObject> _textToSpriteObject;

        void Awake()
        {
            _textToSprite = new Dictionary<string, Sprite>();
            _textToSprite.Add("background1", _background1);
            _textToSprite.Add("background2", _background2);
            _textToSprite.Add("eventCG1", _eventCG1);
            _textToSprite.Add("eventCG2", _eventCG2);
            _textToSprite.Add("eventCG3", _eventCG3);
            _textToSprite.Add("eventCG4", _eventCG4);
            _textToSprite.Add("eventCG5", _eventCG5);

            _textToParentObject = new Dictionary<string, GameObject>();
            _textToParentObject.Add("backgroundObject", _backgroundObject);
            _textToParentObject.Add("eventObject", _eventObject);

            _textToSpriteObject = new Dictionary<string, GameObject>();
        }

        public void PutImage(string imageName, string parentObjectName)
        {
            Sprite image = _textToSprite[imageName];
            GameObject parentObject = _textToParentObject[parentObjectName];

            Vector2 position = new Vector2(0, 0);
            Quaternion rotation = Quaternion.identity;
            Transform parent = parentObject.transform;
            GameObject item = Instantiate(_imagePrefab, position, rotation, parent);
            item.GetComponent<Image>().sprite = image;

            _textToSpriteObject.Add(imageName, item);
        }
        public void RemoveImage(string imageName)
        {
            Destroy(_textToSpriteObject[imageName]);
        }
    }
}