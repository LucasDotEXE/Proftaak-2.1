
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using CommandHelperObjects;

namespace Commands
{
    class Scene
    {
        private readonly static String idPrefix = "scene/";
        public static String get()
        {
            var get = new
            {
                id = "scene/get"
            };
            return JsonConvert.SerializeObject(get);
        }

        public static String reset()
        {
            var reset = new
            {
                id = "scene/reset",
                data = new int[0]
            };
            return JsonConvert.SerializeObject(reset);
        }

        public static String save(String fileName)
        {
            var save = new
            {
                id = "scene/save",
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
                id = "scene/load",
                data = new
                {
                    filename = fileName
                }
            };
            return JsonConvert.SerializeObject(load);
        }

        public static String rayCast(Tuple<double, double, double> start, Tuple<double, double, double> direction, bool phisics)
        {
            var rayCast = new
            {
                id = $"{idPrefix}raycast",
                data = new
                {
                    start = new[] { start.Item1, start.Item2, start.Item3 },
                    direction = direction,
                    phisics = phisics
                }
            };
            return JsonConvert.SerializeObject(rayCast);
        }

        public class node
        {
            public static String add(String name, String parent, Tuple<double, double, double> position, int scale, Tuple<double, double, double> rotation, String fileName)
            {
                var add = new
                {
                    id = "scene/node/add",
                    data = new
                    {
                        name = name,
                        parent = parent,
                        components = new
                        {
                            transform = new
                            {
                                position = new[] { position.Item1, position.Item2, position.Item3 },
                                scale = scale,
                                rotation = new[] { rotation.Item1, rotation.Item2, rotation.Item3 }
                            },
                            model = new
                            {
                                file = fileName,
                                cullbackfaces = true,
                                animated = false,
                                animation = ""
                            },
                            terrain = new
                            {
                                smoothnormals = true
                            },
                            panel = new
                            {
                                size = new[] { 1, 1 },
                                resolution = new[] { 512, 512 },
                                background = new[] { 1, 1, 1, 1 },
                                castShadow = true
                            },
                            water = new
                            {
                                size = new[] { 20, 20 },
                                resolution = 0.1
                            }
                        }
                    }
                };
                return JsonConvert.SerializeObject(add);
            }

            public static String update(String id, String parent, Tuple<double, double, double> position, int scale, Tuple<double, double, double> rotation)
            {
                var update = new
                {
                    id = id,
                    parent = parent,
                    transform = new
                    {
                        position = position,
                        scale = scale,
                        rotation = rotation
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
                    id = "scene/terain/delete",
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

            public static String setTime(int time)
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
        private static readonly String idPrefix = "Route/";

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
            return JsonConvert.SerializeObject(update);
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
            return JsonConvert.SerializeObject(update);
        }

        public static String follow(String routeID, String nodeID, double speed, double ofset, Rotate rotate, double smoothing, bool followHeight, Tuple<double, double, double> rotateOfset, Tuple<double, double, double> positionOffset)
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
                    rotateOffset = new[] { rotateOfset.Item1, rotateOfset.Item2, rotateOfset.Item3 },
                    positionOffset = new[] { positionOffset.Item1, positionOffset.Item2, positionOffset.Item3 }
                }
            };
            return JsonConvert.SerializeObject(follew);
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
            return JsonConvert.SerializeObject(speedFollow);
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
            return JsonConvert.SerializeObject(show);
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
            return JsonConvert.SerializeObject(get);
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
            return JsonConvert.SerializeObject(setCallBack);
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
            return JsonConvert.SerializeObject(play);
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
            return JsonConvert.SerializeObject(pause);
        }
    }


}

namespace CommandHelperObjects
{
    class RouteNode
    {
        private int[] pos { get; set; }
        private int[] dir { get; set; }

        public RouteNode(Tuple<int, int, int> pos, Tuple<int, int, int> dir)
        {
            this.pos = new int[] { pos.Item1, pos.Item2, pos.Item3 };
            this.dir = new int[] { dir.Item1, dir.Item2, dir.Item3 };
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
}
