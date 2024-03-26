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
        switch (type)
        {
            case ConfirmationWindowButtonType.cancel:
                TradeManager.Instance.ToggleConfirmationWindow(/*this.GetComponentInParent<ConfirmationWindow>()*/);
                break;
            case ConfirmationWindowButtonType.confirm:
                if (panel != null)
                {
                    if (TradeManager.Instance.CompleteTransaction(panel))
                    {
                        TradeManager.Instance.ToggleConfirmationWindow();
                    }
                    //Feedback on why a failed transaction took place should come from within the TradeManager
                }
                break;
        }
    }

    public override string ToString()
    {
        return "Button of type " + (type == ConfirmationWindowButtonType.confirm ? "confirm" : "cancel") + " detected";
    }
}
