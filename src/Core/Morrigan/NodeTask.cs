using Nameless.Libraries.Yggdrasil.Lilith;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Yggdrasil.Morrigan
{
    /// <summary>
    /// Defines a node that excecutes an action
    /// </summary>
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Lilith.NamelessObject" />
    /// <seealso cref="Nameless.Libraries.Yggdrasil.Morrigan.ITree{Nameless.Libraries.Yggdrasil.Morrigan.NodeTask}" />
    public class NodeTask : NamelessObject, ITree<NodeTask>
    {
         /// <summary>
        /// Gets a value indicating whether this instance is root.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is root; otherwise, <c>false</c>.
        /// </value>
        public Boolean IsRoot
        {
            get
            {
                return this.HasParent();
            }
        }
        /// <summary>
        /// Gets a value indicating whether this instance is leaf.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is leaf; otherwise, <c>false</c>.
        /// </value>
        public Boolean IsLeaf
        {
            get
            {
                return this.HasChildren();
            }
        }
        /// <summary>
        /// The parent node
        /// </summary>
        public NodeTask Parent
        {
            get;
            set;
        }
        /// <summary>
        /// The node children
        /// </summary>
        public NodeTask[] Children
        {
            get;
            set;
        }
        /// <summary>
        /// Gets node siblings.
        /// </summary>
        /// <value>
        /// The siblings.
        /// </value>
        public NodeTask[] Siblings
        {
            get
            {
                return this.GetSiblings().ToArray();
            }
        }
        /// <summary>
        /// Gets the depth of the node.
        /// The number of edges from the node to the tree's root node.
        /// A root node will have a depth of 0.
        /// </summary>
        /// <value>
        /// The depth.
        /// </value>
        public int Depth
        {
            get
            {
                return this.GetDepth();
            }
        }
        /// <summary>
        /// Gets the height of the node.
        /// The height of a node is the number of edges on the longest path from the node to a leaf.
        /// A leaf node will have a height of 0.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        public int Height
        {
            get
            {
                int height = 0;
                this.GetHeight(ref height);
                return height;
            }
        }
        /// <summary>
        /// Node Action
        /// </summary>
        public Func<Object, Object> Task;
    }
}
