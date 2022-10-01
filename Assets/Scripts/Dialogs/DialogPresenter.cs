using System.Collections.Generic;
using Dialogs.UI;
using UnityEngine;
using UnityEngine.Events;

namespace Dialogs
{
    public class DialogPresenter : MonoBehaviour
    {
        [SerializeField] private DialogView _view;
        [SerializeField] private List<DialogObject> _dialogs;
        [SerializeField] private UnityEvent _onDialogEvent;
        
        private void OnValidate()
        {
            if (_view == null)
                Debug.LogWarning("DialogView was not found!", this);
            if (_dialogs.Count == 0 )
                Debug.LogWarning("DialogObjects was not found!", this);
        }

        private void Awake()
        {
            _view.Hide();
        }

        private void OnEnable()
        {
            foreach (var dialog in _dialogs)
            {
                dialog.OnStart += DialogStartHandler;
                dialog.OnNext += _view.SetPhrase;
                dialog.OnEnd += DialogEndHandler;
            }
        }

        private void OnDisable()
        {
            foreach (var dialog in _dialogs)
            {
                dialog.OnStart -= DialogStartHandler;
                dialog.OnNext -= _view.SetPhrase;
                dialog.OnEnd -= DialogEndHandler;
            }
        }

        private void DialogStartHandler(DialogObject dialog)
        {
            _view.OnNextClick += dialog.NextPhrase;
            _view.Show();
        }

        private void DialogEndHandler(DialogObject dalog)
        {
            _view.OnNextClick -= dalog.NextPhrase;
            _view.Hide();
        }
    }
}
