using System;
using UnityEngine;

namespace Dialogs
{
    [Serializable]
    public class Phrase
    {
        public Phrase(string name, string text)
        {
            _name = name;
            _text = text;
        }

        [SerializeField] private string _name, _text;

        public string Name => _name;
        public string Text => _text;
    }
}