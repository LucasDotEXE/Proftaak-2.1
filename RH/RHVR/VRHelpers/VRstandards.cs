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
            string genPath = "data/NetworkEngine/models/";
            modelPaths.Add("Bike", genPath + "bike/bike.obj");
            modelPaths.Add("Black Car", genPath + "cars/generic/black.obj");
            modelPaths.Add("Blue Car", genPath + "cars/generic/blue.obj");
            modelPaths.Add("White Car", genPath + "cars/generic/white.obj");
            modelPaths.Add("Yellow Car", genPath + "cars/generic/yellow.obj");
            modelPaths.Add("House 1", genPath + "houses/set1/house1.obj");
            modelPaths.Add("House 2", genPath + "houses/set1/house2.obj");
            modelPaths.Add("House 3", genPath + "houses/set1/house3.obj");
            modelPaths.Add("House 4", genPath + "houses/set1/house4.obj");
            modelPaths.Add("Tree 1", genPath + "trees/fantasy/tree1.obj");
            modelPaths.Add("Tree 2", genPath + "trees/fantasy/tree2.obj");
            modelPaths.Add("Tree 3", genPath + "trees/fantasy/tree3.obj");
            modelPaths.Add("Tree 4", genPath + "trees/fantasy/tree4.obj");
            modelPaths.Add("City", genPath + "preset/Amaryllis City/OBJ/Amaryllis City.obj");

            return modelPaths;
        }
    }
}
