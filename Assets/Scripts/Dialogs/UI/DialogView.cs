using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Dialogs.UI
{
    public class DialogView : MonoBehaviour
    {
        [SerializeField] private Button _nextButton;
        [SerializeField] private NameText _nameText;
        [SerializeField] private PhraseText _phraseText;

        public event UnityAction OnNextClick;
        
        private void OnValidate()
        {
            if (_nextButton == null)
                Debug.LogWarning("Button was not found!", this);
            if (_nameText == null)
                Debug.LogWarning("NameText was not found!", this);
            if (_phraseText == null)
                Debug.LogWarning("PhraseText was not found!", this);
        }

        private void Awake()
        {
            _nextButton.onClick.AddListener(() => OnNextClick?.Invoke());
        }

        public void SetPhrase(Phrase phrase)
        {
            if (phrase.Name != string.Empty)
            {
                _nameText.SetName(phrase.Name);
            }
            _phraseText.SetPhrase(phrase.Text);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
