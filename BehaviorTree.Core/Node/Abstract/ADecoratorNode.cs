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
   
   protected abstract TickResult Decorate(ANode pNode, Blackboard pWorldContext, Blackboard pMemory);

   public override TickResult Tick(Blackboard pWorldContext, Blackboard pMemory)
   {
      return Decorate(child!, pWorldContext, pMemory);
   }
}