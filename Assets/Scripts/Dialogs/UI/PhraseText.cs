using TMPro;
using UnityEngine;

namespace Dialogs.UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class PhraseText : MonoBehaviour
    {
        private TMP_Text _text;

        private string Template => $"       {{0}}";
        
        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
            SetPhrase("Теыы");
        }
        
        public void SetPhrase(string phrase)
        {
            _text.SetText(string.Format(Template, phrase));
        }
    }
}
