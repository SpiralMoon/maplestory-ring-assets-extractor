using WzComparerR2.WzLib;

namespace RingAssetsExtractor
{
    public static class Wz_NodeExtension
    {
        /// <summary>
        /// Returns the linked node if a reference link (_outlink) is defined in the node.
        /// Returns the original node if no link is defined.
        /// </summary>
        public static Wz_Node GetLinkedSourceNode(this Wz_Node node, Wz_File wzf)
        {
            string path;

            if (!string.IsNullOrEmpty(path = node.Nodes["_outlink"].GetValueEx<string>(null)))
            {
                string[] fullPath = path.Split("/");
                Wz_Node returnNode = wzf.Node;
                
                foreach (var p in fullPath)
                {
                    returnNode = returnNode.FindNodeByPath(p, p.Contains(".img"));

                    var img = returnNode.GetValue<Wz_Image>();
                    if (img != null && img.TryExtract())
                    {
                        returnNode = img.Node;
                    }
                }

                return returnNode;
            }
            else
            {
                return node;
            }
        }
    }
}
