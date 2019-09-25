using CommandHelperObjects;
using System.Collections.Generic;

namespace GUI_VR_interfacing
{
    static class VREnviorment
    {

        public static void init(Client vrClient)
        {
            addTerain(vrClient, 256, 256);
            Commands.Scene.get(); //see if the groundpane is among it 
            changeTime(vrClient, 12);
            // changeTerrain(vrClient, heightMap.getSlopedHightMap(256, 256, 10), 256, 256);
            /* add3DModdel(vrClient,
                 name: "test",
                 parent: null,
                 pos: new Tripple<double>(3, 3, 3),
                 scale: 1,
                 rot: new Tripple<double>(0, 0, 0),
                 fileName: "FileName");
             addRoute(vrClient, RouteNode.genRouteNodeList());
             */
            Commands.Route.show(true);
        }

        public static void addTerain(Client vrClient, int x, int y)
        {
            vrClient.sendJson(
                            Commands.Scene.terrain.add(
                                x, y, heightMap.getBlankHightMap(x, y)
                                ));
        }

        public static void changeTime(Client vrClient, int time)
        {
            vrClient.sendJson(
                Commands.Scene.skybox.setTime(time)
                );
        }

        public static void changeTerrain(Client vrClient, int[] heightMap, int x, int y)
        {
            vrClient.sendJson(
                Commands.Scene.terrain.delete()
                );

            vrClient.sendJson(
                Commands.Scene.terrain.add(x, y, heightMap)
                );
        }

        public static void add3DModdel(Client vrClient, string name, string parent, Tripple<double> pos, int scale, Tripple<double> rot, string fileName)
        {
            vrClient.sendJson(Commands.Scene.node.add(
                name, parent, pos, scale, rot, fileName
                ));
        }

        public static void addRoute(Client vrClient, List<RouteNode> routeNodes)
        {
            vrClient.sendJson(
                Commands.Route.add(
                    routeNodes
                    ));
        }

        public static void showRoute(Client vrclient, bool doShow)
        {
            vrclient.sendJson(
                Commands.Route.show(doShow)
                );
        }
    }
}
