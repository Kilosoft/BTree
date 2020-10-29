using UnityEngine;

public class Test : MonoBehaviour
{
    public BehTree BehTree;

    private void Start()
    {
        var a = true;  // swich false
        var b = false; // switch true
        var root = new BTSelector("Root");
        {
            var selectA = new BTSequencer("A");
            {
                var isA = new BTCondition("Is A", () => a);
                selectA.AddState(isA);

                var console = new BTAction("Print A", () => Debug.Log("Is A"));
                selectA.AddState(console);
            }
            root.AddState(selectA);

            var selectB = new BTSequencer("B");
            {
                var isB = new BTCondition("Is B", () => b);
                selectB.AddState(isB);

                var console = new BTAction("Print B", () => Debug.Log("Is B"));
                selectB.AddState(console);
            }
            root.AddState(selectB);
        }

        BehTree.AddState(root);
    }
}
