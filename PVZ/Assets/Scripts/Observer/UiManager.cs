using System;
using Singleton;
using TMPro;
using UnityEngine;

namespace Observer
{
    public class UiManager : Observer
    {
        [SerializeField] public TMP_Text totalSunText;

        public override void Notify(Subject subject)
        {
            totalSunText.text = "Sun: " + GameManager.Instance.sun;
        }
    }
}
