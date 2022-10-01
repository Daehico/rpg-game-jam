using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Dialogs
{
    public class DialogObject : MonoBehaviour
    {
        private int _nextPhrase;
            
        [SerializeField] private List<Phrase> _phrases;
        [SerializeField] private UnityEvent _onStartEvent, _onEndEvent;
        [SerializeField] private UnityEvent<int> _onNextEvent;

        public event UnityAction<DialogObject> OnStart, OnEnd;
        public event UnityAction<Phrase> OnNext;

        private void Awake()
        {
            OnStart += dialog => _onStartEvent?.Invoke();
            OnEnd += dialog => _onEndEvent?.Invoke();
            OnNext += phrase => _onNextEvent?.Invoke(_nextPhrase);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerDialogTrigger _player))
            {
                NextPhrase();
            }
        }

        public void NextPhrase()
        {
            if (_nextPhrase >= _phrases.Count)
            {
                OnEnd?.Invoke(this);
                gameObject.SetActive(false);
                return;
            }
            
            if (_nextPhrase == 0)
            {
                OnStart?.Invoke(this);
            }
            
            OnNext?.Invoke(_phrases[_nextPhrase]);
            _nextPhrase++;
        }
    }
}
