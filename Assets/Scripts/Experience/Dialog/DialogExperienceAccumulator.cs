using Dialogs;
using UnityEngine;

namespace Experience.Dialog
{
    [RequireComponent(typeof(DialogObject))]
    public class DialogExperienceAccumulator : ExperienceAccumulator
    {
        private DialogObject _dialogObject;

        private void OnEnable()
        {
            _dialogObject.OnEnd += EndDialogHandler;
        }

        private void OnDisable()
        {
            _dialogObject.OnEnd -= EndDialogHandler;
        }

        private void EndDialogHandler(DialogObject dialog)
        {
            Add();
        }

        protected override void Awake()
        {
            base.Awake();
            _dialogObject = GetComponent<DialogObject>();
        }
    }
}
