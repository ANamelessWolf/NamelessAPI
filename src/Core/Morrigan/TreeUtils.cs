using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Yggdrasil.Morrigan
{
    /// <summary>
    /// This class create utility to manage the functionality of morrigan Aensaland
    /// data structures
    /// </summary>
    public static partial class AenslandUtils
    {
        /// <summary>
        /// Checks if node has parent.
        /// </summary>
        /// <typeparam name="T">The node data type</typeparam>
        /// <param name="node">The tree node.</param>
        /// <returns>True if the node is root</returns>
        public static Boolean HasParent<T>(this ITree<T> node) where T : class
        {
            return node.Parent == null;
        }
        /// <summary>
        /// Checks if node has children.
        /// </summary>
        /// <typeparam name="T">The node data type</typeparam>
        /// <param name="node">The tree node.</param>
        /// <returns>True if the node has children</returns>
        public static Boolean HasChildren<T>(this ITree<T> node) where T : class
        {
            return node.Parent == null;
        }
        /// <summary>
        /// Gets the siblings.
        /// </summary>
        /// <typeparam name="T">The node data type</typeparam>
        /// <param name="node">The tree node.</param>
        /// <returns>The node siblings</returns>
        public static IEnumerable<T> GetSiblings<T>(this ITree<T> node) where T : class
        {
            var parent = node.Parent as ITree<T>;
            return (node.HasParent() || parent.Children.Length == 1) ? new T[0] : parent.Children.Where(x => x != node);
        }
        /// <summary>
        /// Gets the node depth.
        /// </summary>
        /// <typeparam name="T">The node data type</typeparam>
        /// <param name="node">The tree node.</param>
        /// <returns>The node depth</returns>
        public static int GetDepth<T>(this ITree<T> node) where T : class
        {
            int depth = 0;
            var needleNode = node;
            while (needleNode.HasParent())
            {
                depth++;
                needleNode = needleNode.Parent as ITree<T>;
            }
            return depth;
        }
        /// <summary>
        /// Adds the specified child.
        /// </summary>
        /// <typeparam name="T">The node data type</typeparam>
        /// <param name="node">The tree node.</param>
        /// <param name="child">The child to add.</param>
        public static void AddChild<T>(this ITree<T> node, ITree<T> child) where T : class
        {
            if (!node.HasChildren())
                node.Children = new T[1] { child as T };
            else
            {
                var tmp = new T[node.Children.Length + 1];
                for (int i = 0; i < node.Children.Length; i++)
                    tmp[i] = node.Children[i];
                tmp[node.Children.Length] = child as T;
                node.Children = tmp;
            }
        }
        /// <summary>
        /// Gets the node height.
        /// </summary>
        /// <typeparam name="T">The node data type</typeparam>
        /// <param name="node">The tree node.</param>
        /// <returns>The node height</returns>
        internal static int GetHeight<T>(this ITree<T> node, ref int height) where T : class
        {
            if (!node.IsLeaf)
                foreach (var t in node.Children)
                    GetHeight<T>(t as ITree<T>, ref height);
            if (node.Depth > height)
                height = node.Depth;
            return height;
        }
    }
}
