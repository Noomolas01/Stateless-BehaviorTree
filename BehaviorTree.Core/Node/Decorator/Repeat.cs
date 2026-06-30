using BehaviorTree.Core;
using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Tree.DataManagement;
public class Repeat : ADecorator
{
    private readonly int _count;
    public Repeat(int pCount)
    {
        _count = pCount;
    }

    protected override TickResult Decorate(ANode pNode, WorldContext pWorldContext, Blackboard pBlackboard)
    {
        TickResult lChildTickResult = default;

        for(int i = 0; i < _count; i++)
        {
            lChildTickResult = child!.Tick(pWorldContext, pBlackboard);
        }   

        return lChildTickResult;
    }
}