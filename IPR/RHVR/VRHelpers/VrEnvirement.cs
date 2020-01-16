using CommandHelperObjects;
using System.Collections.Generic;
using System.Threading;

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
            add3DModdel(vrClient, "Bike", new
            {
                parent = "Camera",
                model = new
                {
                    file = VRstandards.GenerateModelPaths()["Bike"],
                },
                transform = new
                {
                    scale = 1
                }
            },
            null
            ) ;
            add3DModdel(vrClient, "City", new
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
            List<dynamic> route = new List<dynamic>();
            route.Add(new { pos = new double[] { -19.83, 2.00, 15.93 }, dir = new double[] { -5, 0, 5 } });
            route.Add(new { pos = new double[] { -38.75, 2.00, 15.93 }, dir = new double[] { -5, 0, -5 } });
            route.Add(new { pos = new double[] { -38.75, 2.00, -87.41 }, dir = new double[] { 5, 0, -5 } });
            route.Add(new { pos = new double[] { -19.83, 2.00, -87.41 }, dir = new double[] { 5, 0, 5 }});

          

            addRoute(vrClient,
                routeNodes: route);
           
            


          

        }

        public static void startRoute(Client vrClient)
        {
              followRoute(vrClient,
              routeID: vrClient.nodeDict["Route"],
              nodeID: vrClient.nodeDict["Bike"],
              speed: 2,
              offset: 0,
              rotate: 0,
              smoothing: 1,
              followHeight: false,
              rotateOfset: new double[] { 0, 0, 0 },
              positionOffset: new double[] { 0, -200, 0 }
              );
            followRoute(vrClient,
              routeID: vrClient.nodeDict["Route"],
              nodeID: vrClient.nodeDict["Camera"],
              speed: 2,
              offset: 0,
              rotate: 0,
              smoothing: 1,
              followHeight: true,
              rotateOfset: new double[] { 0, 0, 0 },
              positionOffset: new double[] { 0, -200, 0 }
              );

        }


        public static void addTerain(Client vrClient, int x, int y)
        {
            vrClient.AddToQueue(
                            Commands.Scene.terrain.add(
                                x, y, heightMap.getBlankHightMap(x, y)
                                ));
        }
        public static void followRoute(Client vrClient, string routeID, string nodeID, double speed, double offset, Rotate rotate, double smoothing, bool followHeight, double[] rotateOfset, double[] positionOffset)
        {
            vrClient.AddToQueue(Commands.Route.follow(routeID, nodeID, speed, offset, rotate, smoothing, followHeight, rotateOfset, positionOffset));
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

        public static void addRoute(Client vrClient, List<dynamic> routeNodes)
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
