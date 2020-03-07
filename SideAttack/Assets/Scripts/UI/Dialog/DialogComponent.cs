using UnityEngine;

public class DialogComponent : MonoBehaviour
{
    public UnityEngine.UI.Text titleLabel;
    public UnityEngine.UI.Button noButton, yesButton;

    public IDialogDelegate dialogDelegate;

    public void Accept()
     {
        if (!IsDelegateNull()) {
            dialogDelegate.Accepted();
        }

        Destroy(gameObject);
    }

    public void Decline() {
        if (!IsDelegateNull())
        {
            dialogDelegate.Declined();
        }

        Destroy(gameObject);
    }

    private bool IsDelegateNull() {
        if (dialogDelegate == null)
        {
            throw new System.Exception("Delegate should not be null");
        }

        return false;
    }
}
