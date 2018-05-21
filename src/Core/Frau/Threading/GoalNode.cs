using Nameless.Libraries.Yggdrasil.Morrigan;
using System;

namespace Nameless.Libraries.Yggdrasil.Frau.Threading
{
    /// <summary>
    /// An goal tree also called and–or tree is a graphical representation of the reduction of problems (or goals) to conjunctions and disjunctions of subproblems (or subgoals).
    /// </summary>
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Morrigan.TreeNode" />
    public abstract class GoalNode : TreeNode
    {
        /// <summary>
        /// The node Task
        /// Executed at the constructor definition
        /// </summary>
        public Func<TreeNode, Object, Object> Task;
        /// <summary>
        /// True if the conditions are met, otherwise false
        /// </summary>
        public Boolean AreConditionsMet;
        /// <summary>
        /// The node task result
        /// </summary>
        public Object Result;
        /// <summary>
        /// Initialize a new instance of a goal tree node.
        /// </summary>
        /// <param name="data">The node data</param>
        /// <param name="parent">The parent node data</param>
        /// <param name="runAtStartUp">True if the node task runs at the start up</param>
        public GoalNode(Object data, TreeNode parent, Boolean runAtStartUp = true) :
            base(data, parent)
        {
            this.AreConditionsMet = false;
            if (runAtStartUp && this.Task != null)
                this.Result = this.Task(parent, data);
        }
        /// <summary>
        /// Run the node task. The result of the task is saved on the Result variable
        /// </summary>
        public void Run()
        {
            if (this.Task != null)
                this.Result = this.Task(this.Parent, this.Data);
        }



    }
}
