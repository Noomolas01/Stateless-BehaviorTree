using BehaviorTree.Core;
using BehaviorTree.Core.Node.Abstract;
using BehaviorTree.Core.Tree.DataManagement;

public abstract class ADecorator : ANode
{
   protected ANode? child;

   public void Init(ANode pChild)
   {
      child = pChild;
   }
   
   protected abstract TickResult Decorate(ANode pNode, WorldContext pWorldContext, Blackboard pBlackboard);

   public override TickResult Tick(WorldContext pWorldContext, Blackboard pBlackboard)
   {
      return Decorate(child!, pWorldContext, pBlackboard);
   }
}