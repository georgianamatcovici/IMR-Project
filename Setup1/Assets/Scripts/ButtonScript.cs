using UnityEngine;



public class ButtonScript : MonoBehaviour
{
    public Animator animator;
    public void PlayAnimation()
    {
        if (animator == null)
        {
            Debug.LogWarning("Animator nu e setat!");
            return;
        }
        //messageUI.Show("The purple sodium (Na) atoms react with blue oxygen (O) and red hydrogen (H) atoms from water molecules (H2O), forming sodium hydroxide (NaOH) and releasing hydrogen gas (H2).");

        animator.SetTrigger("TrAnimation");
        Debug.Log("Trigger setat!");
    }
}