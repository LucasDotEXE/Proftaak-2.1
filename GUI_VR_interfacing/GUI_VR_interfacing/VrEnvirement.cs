using CommandHelperObjects;
using System.Collections.Generic;

namespace GUI_VR_interfacing
{
    static class VREnviorment
    {

        public static void init(Client vrClient)
        {
            
            addTerain(vrClient, 1024, 1024);
            //Commands.Scene.get(); //see if the groundpane is among it 
            changeTime(vrClient, 0);
            // changeTerrain(vrClient, heightMap.getSlopedHightMap(256, 256, 10), 256, 256);
            add3DModdel(vrClient, "boom", new
            {
                model = new
                {
                    file = VRstandards.GenerateModelPaths()["City"]
                },
                transform = new
                {
                    scale = 0.005
                }
            },
            null
            );
            List<RouteNode> route = new List<RouteNode>();
            route.Add(new RouteNode(new Tripple<double>(-19.83, 3.00, 15.93), new Tripple<double>(5, 0, -5)));
            route.Add(new RouteNode(new Tripple<double>(-38.75, 3.00, 15.93), new Tripple<double>(5, 0, 5)));
            route.Add(new RouteNode(new Tripple<double>(-38.75, 3.00, -87.41), new Tripple<double>(-5, 0, 5)));
            route.Add(new RouteNode(new Tripple<double>(-19.83, 3.00, -87.41), new Tripple<double>(-5, 0, -5)));

            addRoute(vrClient,
                routeNodes: route);



        }

        public static void addTerain(Client vrClient, int x, int y)
        {
            vrClient.AddToQueue(
                            Commands.Scene.terrain.add(
                                x, y, heightMap.getBlankHightMap(x, y)
                                ));
        }
        public static void followRoute(Client vrClient, string routeID, string nodeID, double speed, double ofset, Rotate rotate, double smoothing, bool followHeight, Tripple<double> rotateOfset, Tripple<double> positionOffset)
        {
            vrClient.AddToQueue(Commands.Route.follow(routeID, nodeID, speed, ofset, rotate, smoothing, followHeight, rotateOfset, positionOffset));
        }

        public static void deleteNode(Client vrClient, string name)
        {
            vrClient.AddToQueue(Commands.Scene.node.delete(name));
        }

        public static void findNode(Client vrClient, string name)
        {
            vrClient.AddToQueue(Commands.Scene.node.find(name));
        }

        public static void changeTime(Client vrClient, float time)
        {
            vrClient.AddToQueue(
                Commands.Scene.skybox.setTime(time)
                );
        }

        public static void changeTerrain(Client vrClient, int[] heightMap, int x, int y)
        {
            vrClient.AddToQueue(
                Commands.Scene.terrain.delete()
                );

            vrClient.AddToQueue(
                Commands.Scene.terrain.add(x, y, heightMap)
                );
        }

        public static void add3DModdel(Client vrClient, string name, dynamic component, string parent)
        {
            vrClient.AddToQueue(Commands.Scene.node.add(
                name, component, parent
                ));
        }

        public static void addRoute(Client vrClient, List<RouteNode> routeNodes)
        {
            vrClient.AddToQueue(
                Commands.Route.add(
                    routeNodes
                    ));
        }

        public static void showRoute(Client vrclient, bool doShow)
        {
            vrclient.AddToQueue(
                Commands.Route.show(doShow)
                );
        }
        public static void getScene(Client client)
        {
            client.AddToQueue(Commands.Scene.get());
        }
    }
}
