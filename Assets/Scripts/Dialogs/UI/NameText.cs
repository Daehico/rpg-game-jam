using TMPro;
using UnityEngine;

namespace Dialogs.UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class NameText : MonoBehaviour
    {
        private TMP_Text _text;

        private string Template => $"{{0}}:";
        
        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
        }
        
        public void SetName(string name)
        {
            _text.SetText(string.Format(Template, name));
        }
    }
}
