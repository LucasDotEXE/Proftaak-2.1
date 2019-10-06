using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using CommandHelperObjects;
using Hangfire.Annotations;

namespace Commands
{
    class Scene
    {
        protected readonly static String idPrefix = "scene/";
        public static String get()
        {
            var get = new
            {
                id = idPrefix + "get"
            };
            return JsonConvert.SerializeObject(get);
        }

        public static String reset()
        {
            var reset = new
            {
                id = idPrefix + "reset",
                data = new int[0]
            };
            return JsonConvert.SerializeObject(reset);
        }

        public static String save(String fileName)
        {
            var save = new
            {
                id = idPrefix + "save",
                data = new
                {
                    filename = fileName,
                    overwrite = false
                }
            };
            return JsonConvert.SerializeObject(save);
        }

        public static String load(String fileName)
        {
            var load = new
            {
                id = idPrefix + "load",
                data = new
                {
                    filename = fileName
                }
            };
            return JsonConvert.SerializeObject(load);
        }

        public static String rayCast(Tripple<double> start,
            Tripple<double> direction, bool phisics)
        {
            var rayCast = new
            {
                id = idPrefix + "raycast",
                data = new
                {
                    start = new[] { start.val[0], start.val[1], start.val[2] },
                    direction = direction,
                    phisics = phisics
                }
            };


            return JsonConvert.SerializeObject(rayCast);
        }

        public class node
        {
            private readonly static String idPrefix = Scene.idPrefix + "node/";
            public static String add([NotNull]String name, dynamic component = null, string parent = null)
            {

                Dictionary<string, dynamic> add = new Dictionary<string, dynamic>();

                add.Add("id", idPrefix + "add");

                Dictionary<string, dynamic> data = new Dictionary<string, dynamic>();

                    data.Add("name", name);

                if (parent != null) data.Add("parent", parent);

                if (component != null) data.Add("components",component);

                add.Add("data",data);

                
                return JsonConvert.SerializeObject(add);
            }

            public static String update(String id, String parent, Tripple<double> position, int scale, Tripple<double> rotation)
            {
                var update = new
                {

                    id = idPrefix + "update",
                    data = new
                    {
                        id = id,
                        parent = parent,
                        transform = new
                        {
                            position = position.val,
                            scale = scale,
                            rotation = rotation.val
                        }
                    }
                };
                return JsonConvert.SerializeObject(update);
            }
            public static String delete(String id)
            {
                var delete = new
                {
                    id = idPrefix + "delete"
           ,
                    data = new
                    {
                        id = id
                    }
                };
                return JsonConvert.SerializeObject(delete);
            }
            public static String find(String name)
            {
                var find = new
                {
                    id = idPrefix + "find",

                    data = new
                    {
                        name = new { name }
                    }
                };
                return JsonConvert.SerializeObject(find);

            }
            public static String addLayer(String id, String diffuseTexture, String normalTexture, int minHeight, int maxHeight, int fadeDist)
            {
                var addLayer = new
                {
                    id = idPrefix + "addlayer",

                    data = new
                    {
                        id = id,
                        diffuse = new
                        {
                            diffuseTexture
                        },
                        normal = new
                        {
                            normalTexture
                        },
                        minHeight = minHeight,
                        maxHeight = maxHeight,
                        fadeDist = fadeDist

                    }

                };
                return JsonConvert.SerializeObject(addLayer);
            }
            public static String delLayer()
            {
                var delLayer = new
                {
                    id = idPrefix + "dellayer",
                    data = new { }
                };
                return JsonConvert.SerializeObject(delLayer);
            }
        }

        public class terrain
        {
            private readonly static String idPrefix = Scene.idPrefix + "terrain/";

            public static String add(int xSize, int ySize, int[] heights)
            {
                var add = new
                {
                    id = idPrefix + "add",
                    data = new
                    {
                        size = new[] { xSize, ySize },
                        heights = heights  // size X times size Y
                    }
                };
                return JsonConvert.SerializeObject(add);
            }

            public static String update()
            {
                var update = new
                {
                    id = idPrefix + "update",
                    data = new
                    {

                    }
                };
                return JsonConvert.SerializeObject(update);
            }

            public static String delete()
            {
                var delete = new
                {
                    id = idPrefix + "delete",
                    data = new
                    {

                    }
                };
                return JsonConvert.SerializeObject(delete);
            }

            public static String getHeight(Tuple<double, double> position, List<Tuple<double, double>> points)
            {
                List<double[]> cords = new List<double[]>();
                foreach (Tuple<double, double> point1 in points)
                {
                    cords.Add(new double[] { point1.Item1, point1.Item2 });
                }

                var getHeight = new
                {
                    id = idPrefix + "getheight",
                    data = new
                    {
                        position = new[] { position.Item1, position.Item2 },
                        positions = cords
                    }
                };
                return JsonConvert.SerializeObject(getHeight);
            }
        }

        public class panel
        {
            String idPefix = Scene.idPrefix + "panel/";

            public static String clear(String id)
            {
                var clear = new
                {
                    id = idPrefix + "clear",
                    data = new
                    {
                        id = id
                    }
                };
                return JsonConvert.SerializeObject(clear);
            }

            public static String swap(String id)
            {
                var swap = new
                {
                    id = idPrefix + "swap",
                    data = new
                    {
                        id = id
                    }
                };
                return JsonConvert.SerializeObject(swap);
            }

            public static String drawLines(String id, double width, List<Line> lines)
            {
                var drawLines = new
                {
                    id = idPrefix + "drawlines",
                    data = new
                    {
                        id = id,
                        width = width,
                        lines = lines.ToArray()
                    }
                };
                return JsonConvert.SerializeObject(drawLines);
            }

            public static String setClearColor(String panalId, RGBA color)
            {
                var setClearColor = new
                {
                    id = idPrefix + "setclearcolor",
                    data = new
                    {
                        id = new { panalId },
                        color = color.rgba
                    }
                };
                return JsonConvert.SerializeObject(setClearColor);
            }

            public static String drawText(String id, String text, Tuple<double, double> pos, double size, RGBA color, String font)
            {
                var drawText = new
                {
                    id = idPrefix + "drawtext",
                    data = new
                    {
                        id = new { id },
                        text = text,
                        position = new[] { pos.Item1, pos.Item2 },
                        size = size,
                        color = color.rgba,
                        font = font
                    }
                };
                return JsonConvert.SerializeObject(drawText);
            }

            public static String image(String panelId, String imagePath, Tuple<double, double> pos, Tuple<double, double> size)
            {
                var image = new
                {
                    id = idPrefix + "image",
                    data = new
                    {
                        id = new { panelId },
                        image = imagePath,
                        position = new[] { pos.Item1, pos.Item2 },
                        size = new[] { size.Item1, size.Item2 }
                    }
                };
                return JsonConvert.SerializeObject(image);
            }

        }

        public class skybox
        {
            private static readonly String idPrefix = Scene.idPrefix + "skybox/";

            public static String setTime(float time)
            {
                var setTime = new
                {
                    id = idPrefix + "settime",
                    data = new
                    {
                        time = time
                    }
                };
                return JsonConvert.SerializeObject(setTime);
            }
        }

        public static String update(String type, String xPos, String xNeg, String yPos, String yNeg, String zPos, String zNeg)
        {
            var update = new
            {
                id = idPrefix + "update",
                data = new
                {
                    type = type,
                    files = new
                    {
                        xpos = xPos,
                        xneg = xNeg,
                        ypos = yPos,
                        yneg = yNeg,
                        zpos = zPos,
                        zneg = zNeg
                    }
                }

            };
            return JsonConvert.SerializeObject(update);
        }
    }

    class Route
    {
        private static readonly String idPrefix = "route/";

        public static String add(List<RouteNode> nodes)
        {

            var add = new
            {
                id = idPrefix + "add",
                data = new
                {
                    nodes = nodes.ToArray()
                }
            };
            return JsonConvert.SerializeObject(add);
        }
        public static String update(String id, List<RouteNode> nodes)
        {

            var update = new
            {
                id = idPrefix + "update",
                data = new
                {
                    id = id,
                    nodes = new[]
                    {
                        nodes
                    }
                }
            };
            return HelpMethods.lowerAndRemoveSpace(JsonConvert.SerializeObject(update));
        }

        public static String delete(String id)
        {
            var update = new
            {
                id = idPrefix + "delete",
                data = new
                {
                    id = id
                }
            };
            return HelpMethods.lowerAndRemoveSpace(JsonConvert.SerializeObject(update));
        }

        public static String follow(String routeID, String nodeID, double speed, double ofset, Rotate rotate, double smoothing, bool followHeight, Tripple<double> rotateOfset, Tripple<double> positionOffset)
        {
            var follew = new
            {
                id = idPrefix + "follow",
                data = new
                {
                    route = new { routeID },
                    node = new { nodeID },
                    speed = speed,
                    offset = ofset,
                    rotate = rotate,
                    smoothing = smoothing,
                    followHeight = followHeight,
                    rotateOffset = new[] { rotateOfset.val[0], rotateOfset.val[1], rotateOfset.val[2] },
                    positionOffset = new[] { positionOffset.val[0], positionOffset.val[1], positionOffset.val[2] }
                }
            };
            return HelpMethods.lowerAndRemoveSpace(JsonConvert.SerializeObject(follew));
        }
        public static String followSpeed(String id, double speed)
        {
            var speedFollow = new
            {
                id = idPrefix + "follow/speed",
                data = new
                {
                    node = new { id },
                    speed = speed
                }
            };
            return HelpMethods.lowerAndRemoveSpace(JsonConvert.SerializeObject(speedFollow));
        }

        public static String show(bool showLine)
        {
            var show = new
            {
                id = idPrefix + "show",
                data = new
                {
                    show = showLine
                }
            };
            return HelpMethods.lowerAndRemoveSpace(JsonConvert.SerializeObject(show));
        }
    }

    class Engine
    {
        public static String get(GetType type)
        {
            var get = new
            {
                id = "get",
                data = new
                {
                    type = type
                }
            };
            return HelpMethods.lowerAndRemoveSpace(JsonConvert.SerializeObject(get));
        }

        public static String setCallBack(ButtonType buttonType, HandType handType)
        {
            var setCallBack = new
            {
                id = "setcallback",
                data = new
                {
                    type = "button",
                    button = buttonType,
                    hand = handType

                }
            };
            return HelpMethods.lowerAndRemoveSpace(JsonConvert.SerializeObject(setCallBack));
        }

        public static String play()
        {
            var play = new
            {
                id = "play",
                data = new
                {

                }
            };
            return HelpMethods.lowerAndRemoveSpace(JsonConvert.SerializeObject(play));
        }

        public static String pause()
        {
            var pause = new
            {
                id = "pause",
                data = new
                {

                }
            };
            return HelpMethods.lowerAndRemoveSpace(JsonConvert.SerializeObject(pause));
        }
    }
}


namespace CommandHelperObjects
{
    class HelpMethods
    {
        public static String lowerAndRemoveSpace(String input)
        {
            return input.Replace(" ", "").ToLower();
        }
    }

    namespace Components
    {
        class Component
        {
            public static dynamic getModel([NotNull] String fileName, bool cullback = false, bool animeted = false, String animation = null)
            {
                var model = new Dictionary<String, dynamic>() { { "file", fileName }, { "cullbackfaces", cullback }, { "animeted", animeted } };
                if (animeted)
                {
                    model.Add("animetion", animation);
                }
                return model;
            }
            public static dynamic getTerain(bool smoothnormals = false)
            {
                return new
                {
                    smoothnormals = smoothnormals
                };
            }
            public static dynamic getPanel(int[] size = null, int[] resolution = null, int[] background = null, bool castShadow = true)
            {
                var panel = new Dictionary<String, dynamic>();
                if (size == null)
                {

                }
                else
                {

                }

                if (resolution == null)
                {

                }
                else
                {

                }

                if (background == null)
                {

                }
                else
                {

                }

                return panel;
            }
            public static dynamic getWater()
            {
                throw new NotImplementedException();
            }
            public static dynamic getTransform(Tripple<double> position = null, int scale = 1, Tripple<double> rotation = null)
            {
                var transform = new Dictionary<String, dynamic>() { { "scale", scale } };
                if (position == null)
                {
                    transform.Add("position", new Tripple<double>(0, 0, 0));
                }
                else
                {
                    transform.Add("position", new Tripple<double>(position.val[0], position.val[1], position.val[2]));
                }
                if (rotation == null)
                {
                    transform.Add("rotation", new Tripple<double>(0, 0, 0));
                }
                else
                {
                    transform.Add("rotation", new Tripple<double>(rotation.val[0], rotation.val[1], rotation.val[2]));
                }
                return transform;
            }
        }

        class Panel : Component
        {


            public dynamic getDynamic()
            {
                throw new NotImplementedException();
            }
        }

        class Water : Component
        {
            public dynamic getDynamic()
            {
                throw new NotImplementedException();
            }
        }

        public class Transform
        {
            internal dynamic getVarInstance()
            {
                return new
                {

                };
            }
        }
    }


    class RouteNode
    {
        private int[] pos { get; set; }
        private int[] dir { get; set; }

        public RouteNode(Tripple<int> pos, Tripple<int> dir)
        {
            this.pos = new int[] { pos.val[0], pos.val[1], pos.val[2] };
            this.dir = new int[] { dir.val[0], dir.val[1], dir.val[2] };
        }

        public static List<RouteNode> genRouteNodeList()
        {
            List<RouteNode> nodes = new List<RouteNode>();

            nodes.Add(new RouteNode(new Tripple<int>(0, 0, 0), new Tripple<int>(5, 0, -5)));
            nodes.Add(new RouteNode(new Tripple<int>(50, 0, 1), new Tripple<int>(5, 0, 5)));
            nodes.Add(new RouteNode(new Tripple<int>(50, 0, 50), new Tripple<int>(-5, 0, 5)));
            nodes.Add(new RouteNode(new Tripple<int>(0, 0, 50), new Tripple<int>(-5, 0, -5)));

            return nodes;
        }
    }

    class Tripple<T>
    {
        public T[] val { get; set; }

        public Tripple(T x, T y, T z)
        {
            this.val = new T[3] { x, y, z };
        }

    }
    enum Rotate { NONE, XZ, XYZ }
    enum GetType { HEAD, HANDLEFT, HANDRIGHT, BUTTON }
    enum ButtonType { TRIGGER, THUMBPAD, APPLICATION, GRIP }
    enum HandType { LEFT, RIGHT }

    class Line
    {
        private double[] lineData { get; set; }

        public Line(Tuple<int, int> point1, Tuple<int, int> point2, RGBA rgba)
        {
            lineData = new double[] { point1.Item1, point1.Item2, point2.Item1, point2.Item2, rgba.rgba[0], rgba.rgba[1], rgba.rgba[2], rgba.rgba[3] };
        }
    }

    class RGBA
    {
        public double[] rgba { get; set; }

        public RGBA(Tuple<double, double, double, double> rgba)
        {
            this.rgba = new double[] { rgba.Item1, rgba.Item2, rgba.Item3, rgba.Item4 };
        }
    }

    class heightMap
    {
        public static int[] getBlankHightMap(int x, int y)
        {
            return new int[x * y];
        }

        public static int[] getSlopedHightMap(int x, int y, int maxHight)
        {
            int[] map = new int[x * y];
            for (int i = 0; i < x; i++)
            {
                for (int o = 0; o < y; o++)
                {
                    map[i * x + o] = o / y * maxHight;
                }
            }
            return map;
        }
    }
}
