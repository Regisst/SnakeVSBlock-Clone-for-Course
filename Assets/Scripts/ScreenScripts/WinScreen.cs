using System.Collections;
using UnityEngine;

namespace Assets.Scripts.ScreenScripts
{
    public class WinScreen : Screen
    {
        [SerializeField] private GameObject _button;
        [SerializeField] private GameObject _text;
        public override void HideScreen()
        {
            _setObjectsStatus(false);
        }

        public override void ShowScreen()
        {
            _setObjectsStatus(true);
        }

        private void _setObjectsStatus(bool status)
        {
            _button.SetActive(status);
            _text.SetActive(status);
        }
    }
}