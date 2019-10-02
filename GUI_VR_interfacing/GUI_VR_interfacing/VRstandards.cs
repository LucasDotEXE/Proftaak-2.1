using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_VR_interfacing
{
    static class VRstandards
    {
        public static  Dictionary<string, string> GenerateModelPaths()
        {
            Dictionary<string, string> modelPaths = new Dictionary<string, string>();
            string genPath = "NetworkEngine/data/NetworkEngine/models/";
            modelPaths.Add("Bike", genPath + "bike/bike.obj");
            modelPaths.Add("Black Car", "cars/generic/black.obj");
            modelPaths.Add("Blue Car", "cars/generic/blue.obj");
            modelPaths.Add("White Car", "cars/generic/white.obj");
            modelPaths.Add("Yellow Car", "cars/generic/yellow.obj");
            modelPaths.Add("House 1", "houses/set1/house1.obj");
            modelPaths.Add("House 2", "houses/set1/house2.obj");
            modelPaths.Add("House 3", "houses/set1/house3.obj");
            modelPaths.Add("House 4", "houses/set1/house4.obj");
            modelPaths.Add("Tree 1", "trees/fantasy/tree1.obj");
            modelPaths.Add("Tree 2", "trees/fantasy/tree2.obj");
            modelPaths.Add("Tree 3", "trees/fantasy/tree3.obj");
            modelPaths.Add("Tree 4", "trees/fantasy/tree4.obj");

            return modelPaths;
        }
    }
}
