using Nameless.Libraries.Yggdrasil.Morrigan;
using System;

namespace Nameless.Libraries.Yggdrasil.Frau.Threading
{
    /// <summary>
    /// Or node defines a task that is solved by a group of options
    /// </summary>
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Morrigan.TreeNode" />
    public class OrNode : GoalNode
    {
        /// <summary>
        /// Initialize the or node
        /// </summary>
        /// <param name="data">The object data</param>
        /// <param name="parent">The parent node</param>
        /// <param name="nodes">The children nodes</param>
        public OrNode(object data, TreeNode parent, GoalNode[] nodes) :
            base(data, parent)
        {
            int index = 0;
            while (!this.AreConditionsMet && index < nodes.Length)
            {
                nodes[index].Run();
                this.AreConditionsMet = nodes[index].AreConditionsMet;
                index++;
            }
            if(this.AreConditionsMet)
            {
                this.Task = nodes[index].Task;
                this.Result = nodes[index].Result;
            }
        }
    }
}
