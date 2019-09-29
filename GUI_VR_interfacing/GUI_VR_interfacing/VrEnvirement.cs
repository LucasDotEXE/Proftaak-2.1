using CommandHelperObjects;
using System.Collections.Generic;

namespace GUI_VR_interfacing
{
    static class VREnviorment
    {

        public static void init(Client vrClient)
        {
            //addTerain(vrClient, 256, 256);
            //Commands.Scene.get(); //see if the groundpane is among it 
            changeTime(vrClient, 0);
            add3DModdel(vrClient,
                name: "test",
                parent: null,
                pos: new Tripple<double>(1, 1, 1),
                scale: 1,
                rot: new Tripple<double>(0, 0, 0),
                fileName: "Models/girl-brunette.blend");
            // changeTerrain(vrClient, heightMap.getSlopedHightMap(256, 256, 10), 256, 256);
            add3DModdel(vrClient,
                name: "test",
                parent: null,
                pos: new Tripple<double>(1, 1, 1),
                scale: 1,
                rot: new Tripple<double>(0, 0, 0),
                fileName: "data/NetworkEngine/models/trees/fantasy/tree1.obj");
            // addRoute(vrClient, RouteNode.genRouteNodeList());

            //Commands.Route.show(true);
        }

        public static void addTerain(Client vrClient, int x, int y)
        {
            vrClient.addToQueue(
                            Commands.Scene.terrain.add(
                                x, y, heightMap.getBlankHightMap(x, y)
                                ));
        }

        public static void changeTime(Client vrClient, double time)
        {
            vrClient.addToQueue(
                Commands.Scene.skybox.setTime(time)
                );
        }

        public static void changeTerrain(Client vrClient, int[] heightMap, int x, int y)
        {
            vrClient.addToQueue(
                Commands.Scene.terrain.delete()
                );

            vrClient.addToQueue(
                Commands.Scene.terrain.add(x, y, heightMap)
                );
        }

        public static void add3DModdel(Client vrClient, string name, string parent, Tripple<double> pos, int scale, Tripple<double> rot, string fileName)
        {
            vrClient.addToQueue(Commands.Scene.node.add(
                name, parent, pos, scale, rot, fileName
                ));
        }

        public static void addRoute(Client vrClient, List<RouteNode> routeNodes)
        {
            vrClient.addToQueue(
                Commands.Route.add(
                    routeNodes
                    ));
        }

        public static void showRoute(Client vrclient, bool doShow)
        {
            vrclient.addToQueue(
                Commands.Route.show(doShow)
                );
        }
        public static void getScene(Client client)
        {
            client.addToQueue(Commands.Scene.get());
        }
    }
}
