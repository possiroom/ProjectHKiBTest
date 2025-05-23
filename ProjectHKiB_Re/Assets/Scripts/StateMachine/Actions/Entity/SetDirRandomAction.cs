using UnityEngine;
[CreateAssetMenu(fileName = "SetDirRandomAction", menuName = "Scriptable Objects/State Machine/Action/SetDirRandomAction", order = 3)]
public class SetDirRandomAction : StateActionSO
{
    [SerializeField] private bool negative;
    public override void Act(StateController stateController)
    {
        if (stateController.TryGetInterface(out IEntityStateController controller))
        {
            Vector2 dir = Vector2.up * Random.Range(-1, 2) + Vector2.right * Random.Range(-1, 2);
            if (!controller.AnimationController.CheckIfLastSetDirectionSame(dir))
                controller.AnimationController.SetAnimationDirection(negative ? dir * -1 : dir);
        }

    }
}
