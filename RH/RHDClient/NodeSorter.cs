using System.Collections;
using System.Windows.Forms;

namespace DocterAplication
{
    internal class NodeSorter : IComparer
    {
        public int Compare(object x, object y)
        {
            TreeNode tx = x as TreeNode;
            TreeNode ty = y as TreeNode;

            if (tx.Name == null || ty.Name == null)
                return 0;
            return (-1) * string.Compare(tx.Name.ToString(), ty.Name.ToString());
        }

    }
}