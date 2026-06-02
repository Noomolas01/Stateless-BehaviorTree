namespace BehaviorTree.Core.Node.Abstract;

public abstract class AActionNode (string pName = "") : ANode(pName)
{
    protected abstract Result Do();

    public override Result Tick()
    {
        return Do();
    }
}
