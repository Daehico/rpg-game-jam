using DuloGames.UI;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(UIProgressBar))]
    public class HealthProgressBar : MonoBehaviour
    {
        public UIProgressBar ProgressBar => GetComponent<UIProgressBar>();
    }
}
