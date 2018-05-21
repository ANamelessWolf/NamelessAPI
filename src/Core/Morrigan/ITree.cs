using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Yggdrasil.Morrigan
{
    /// <summary>
    /// This interface define the data structure of a tree
    /// </summary>
    public interface ITree<T>
    {
        /// <summary>
        /// Gets a value indicating whether this instance is root.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is root; otherwise, <c>false</c>.
        /// </value>
        Boolean IsRoot { get; }
        /// <summary>
        /// Gets a value indicating whether this instance is leaf.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is leaf; otherwise, <c>false</c>.
        /// </value>
        Boolean IsLeaf { get; }
        /// <summary>
        /// The parent node
        /// </summary>
        T Parent { get; set; }
        /// <summary>
        /// The node children
        /// </summary>
        T[] Children { get; set; }
        /// <summary>
        /// Gets node siblings.
        /// </summary>
        /// <value>
        /// The siblings.
        /// </value>
        T[] Siblings { get; }
        /// <summary>
        /// Gets the depth of the node.
        /// The number of edges from the node to the tree's root node.
        /// A root node will have a depth of 0.
        /// </summary>
        /// <value>
        /// The depth.
        /// </value>
        int Depth { get; }
        /// <summary>
        /// Gets the height of the node.
        /// The height of a node is the number of edges on the longest path from the node to a leaf.
        /// A leaf node will have a height of 0.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        int Height { get; }
    }
}