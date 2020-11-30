namespace dev.objects
{
    public class ImmutableListNode
    {
       private int val;

       private ImmutableListNode nextNode;

       public int PrintValue()
       {
           return this.val;
       }

       public ImmutableListNode GetNext()
       {
           return this.nextNode;
       }
    }
}