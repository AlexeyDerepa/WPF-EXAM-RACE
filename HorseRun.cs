using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOPOLNENIE_003
{
    class HorseRun
    {
        private Random _rand;
        public static bool _flagEnd;
        private bool _winer;
        private bool _looser;
        private double _path;
        private double _duration;

        public double path { get { return _path; } }
        public bool winer { get { return _winer; } set { _winer = value; } }
        public bool looser { get { return _looser; } set { _looser = value; } }
        public HorseRun()
        {
            _rand = new Random();
            Initialization();
        }
        public void Initialization()
        {
            _flagEnd = false;
            _winer = false;
            _looser = false;
            _path = 0.0;
            _duration = _rand.Next(2, 5) * _rand.NextDouble();
            System.Threading.Thread.Sleep(20);
        }
        public static HorseRun operator ++(HorseRun a)
        {
            a._path += a._duration;
            return a;
        }
    }
}
