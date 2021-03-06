using System;
using System.Collections.Generic;

namespace Advent3
{
    public struct Line {
        public int X1 {get;set;}
        public int X2 {get;set;}
        public int Y1 {get;set;}
        public int Y2 {get;set;}
        public Line(int x1, int x2, int y1, int y2) {
            X1 = x1; X2 = x2; Y1 = y1; Y2 = y2;
        }
    }

    public class Advent3 {
        string[] movesRouteA = RawData.dataForAdvent3()[0].Split(",");
        string[] movesRouteB = RawData.dataForAdvent3()[1].Split(",");

        Dictionary<int, List<Line>> horizontals = new Dictionary<int, List<Line>>();
        Dictionary<int, List<Line>> verticals = new Dictionary<int, List<Line>>();

        public Tuple<int, int> getShortestPath() {
            var lineA = new Line(0, 0, 0, 0);
            var lineB = new Line(0, 0, 0, 0);
            int minHorSteps = 100000; var minVerSteps = 100000;


            // for (int i = 0; i < Math.Max(movesRouteA.Length, movesRouteB.Length); i++) {
            //     if (i < movesRouteA.Length) lineA = calculateMove(lineA, movesRouteA[i]);
            //     if (i < movesRouteB.Length) lineB = calculateMove(lineB, movesRouteB[i]);

            //     var dist = intersects(lineA, lineB);
            //     if ((Math.Abs(dist.Item1)+Math.Abs(dist.Item2))>0) {
            //         if ((Math.Abs(dist.Item1) + Math.Abs(dist.Item2)) 
            //             < (Math.Abs(minHorSteps) + Math.Abs(minVerSteps))) {
            //             minHorSteps = dist.Item1; minVerSteps = dist.Item2;
            //         }
            //         Console.WriteLine("Crossed at step "+i+" distance is "+dist.Item1+" + "+dist.Item2);
            //     }
            // }
            return new Tuple <int, int>(minHorSteps, minVerSteps);
        }
        Tuple<int, int> intersects(Line lineA, Line lineB) {
            // 2 parallel cases
            if (lineA.X2 == lineA.X1 && lineB.X2 == lineB.X1) new Tuple<int, int> (0, 0);
            if (lineA.Y2 == lineA.Y1 && lineB.Y2 == lineB.Y1) new Tuple<int, int> (0, 0);
            
            Line vert = lineA.X2 == lineA.X1 ? lineA : lineB;
            Line horiz = lineA.X2 == lineA.X1 ? lineB : lineA;
            int yUpper = vert.Y2 > vert.Y1 ? vert.Y2 : vert.Y1;
            int yLower = vert.Y2 < vert.Y1 ? vert.Y2 : vert.Y1;
            int y = horiz.Y2;
            int xLeft = horiz.X2 < horiz.X1 ? horiz.X2 : horiz.X1;
            int xRight = horiz.X2 > horiz.X1 ? horiz.X2 : horiz.X1;
            int x = vert.X2;
            
            if (x >= xLeft && x <= xRight && y >= yLower && y <= yUpper) return new Tuple<int, int> (x, y);
            return new Tuple<int, int> (0, 0);
        }
        
        void calculateMovesAndMaps(string[] moves) {
            Line line = new Line(0,0,0,0);
            for (int i = 0; i < moves.Length; i++) {
                var x = 0; var y = 0;
                var move = Int32.Parse(moves[i].Substring(1));
                var dir = moves[i].Substring(0,1);
                if (dir.Equals("U")) y = move;
                if (dir.Equals("R")) x = move;
                if (dir.Equals("L")) x = -move;
                if (dir.Equals("D")) y = -move;
                Line linePrev = line;
                line = new Line(linePrev.X2, linePrev.X2 + x, linePrev.Y2, linePrev.Y2 + y);
                if (x == 0) {
                    verticals = addNewLineToLinesDictionary(verticals, line, x);
                } else if (y==0) {
                    horizontals = addNewLineToLinesDictionary(horizontals, line, y);
                }        
            }
        } 

        Dictionary<int, List<Line>> addNewLineToLinesDictionary(Dictionary<int, List<Line>> linesDict, Line line, int z) {
            List<Line> list;
            if (linesDict.TryGetValue(z, out list)) list = linesDict[z];
            else list = new List<Line>();
            list.Add(line);
            linesDict.Add(z, list);
            return linesDict;
        }
    }
}