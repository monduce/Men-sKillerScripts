using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Nove1Game;

namespace NovelGame
{
    public class UserScriptManager : MonoBehaviour
    {
        [SerializeField] TextAsset _textFile;

        List<string> _sentences = new List<string>();

        void Awake()
        {
            StringReader reader = new StringReader(_textFile.text);
            while (reader.Peek() != -1)
            {
                string line = reader.ReadLine();
                _sentences.Add(line);
            }
        }

        public string GetCurrentSentence()
        {
            int count = _sentences.Count;

            if (count < 0 || count <= GameManager.Instance.lineNumber)
            {
                return null;
            }
            return _sentences[GameManager.Instance.lineNumber];
        }
        
        public bool IsStatement(string sentence)
        {
            if (sentence != null && sentence[0] == '&')
            {
                return true;
            }
            return false;
        }

        public void ExecuteStatement(string sentence)
        {
            string[] words = sentence.Split(' ');
            switch (words[0])
            {
                case "&img":
                    GameManager.Instance.imageManager.PutImage(words[1], words[2]);
                    break;
                case "&rmimg":
                    GameManager.Instance.imageManager.RemoveImage(words[1]);
                    break;
            }
        }
    }
}