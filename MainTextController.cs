using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Nove1Game;
using JetBrains.Annotations;
using UnityEngine.UI;
using Unity.VisualScripting;
using System;

namespace NovelGame
{
    public class MainTextController : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _mainTextObject;
        int _displayedSentenceLength;
        int _sentenceLength;
        float _time;
        float _feedTime;

        public bool myButton;

        public GameObject Button;
       
        void Start()
        {
            _time = 0f;
            _feedTime = 0.05f;
            string statement = GameManager.Instance.userScriptManager.GetCurrentSentence();
            if (GameManager.Instance.userScriptManager.IsStatement(statement))
            {
                GameManager.Instance.userScriptManager.ExecuteStatement(statement);
                GoToTheNextLine();
            }
            DisplayText();
        }

        void Update()
        {
            _time += Time.deltaTime;
            if (_time >= _feedTime)
            {
                _time -= _feedTime;
                if (!CanGoToTheNextLine())
                {
                    _displayedSentenceLength++;
                    _mainTextObject.maxVisibleCharacters = _displayedSentenceLength;
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (CanGoToTheNextLine())
                {
                    GoToTheNextLine();
                    DisplayText();
                }
                else
                {
                    _displayedSentenceLength = _sentenceLength;
                }
            }
        }

        public bool CanGoToTheNextLine()
        {
            string sentence = GameManager.Instance.userScriptManager.GetCurrentSentence();
            if (sentence == null)
                return false;


            _sentenceLength = sentence.Length;
            return (_displayedSentenceLength > sentence.Length);
        }

        public void GoToTheNextLine()
        {
            _displayedSentenceLength = 0;
            _time = 0f;
            _mainTextObject.maxVisibleCharacters = 0;


            GameManager.Instance.lineNumber++;
            string sentence = GameManager.Instance.userScriptManager.GetCurrentSentence();
            if (GameManager.Instance.userScriptManager.IsStatement(sentence))
            {
                GameManager.Instance.userScriptManager.ExecuteStatement(sentence);
                GoToTheNextLine();
            }

            if (sentence == null)
            {
                if (myButton == true)
                {
                    Button.SetActive(true);
                }
            }

           

        }

        private void ShowButton()
        {
            throw new NotImplementedException();
        }

        public void DisplayText()
        {
            string sentence = GameManager.Instance.userScriptManager.GetCurrentSentence();
            _mainTextObject.text = sentence;
        }
    }
}