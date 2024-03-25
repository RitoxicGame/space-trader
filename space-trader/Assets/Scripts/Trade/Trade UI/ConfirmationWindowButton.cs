using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ConfirmationWindowButtonType { cancel, confirm }

public class ConfirmationWindowButton : MonoBehaviour
{
    public TradeWindowPanel panel;
    public ConfirmationWindowButtonType type;

    public void OnClick()
    {
        if (panel != null)
        {
            switch (type)
            {
                case ConfirmationWindowButtonType.cancel:
                    TradeManager.Instance.ToggleConfirmationWindow(this.GetComponentInParent<ConfirmationWindow>());
                    break;
                case ConfirmationWindowButtonType.confirm:
                    break;
            }
        }
    }
}
