using System;
using System.Drawing;
using TStateMachine;

namespace TStateMachineLibrary
{
    public class TCanvas
    {
        private static readonly Lazy<TCanvas> lazy =
            new Lazy<TCanvas>(() => new TCanvas());

        public static TCanvas Instance { get { return lazy.Value; } }

        private TCanvas()
        {
        }

        ~TCanvas()
        {
            _disposer.Dispose();
        }

        private Disposer _disposer = new Disposer();

        public  Color FontColor { get; set; }
        public  Brush Brush { get; set; }

        private  Pen _myPen;
        /// <summary>
        /// Pen把计て絋﹚ミΩ
        /// </summary>
        public  Pen MyPen
        {
            get
            {
                if (_myPen == null)
                {
                    _myPen = new Pen(Color.Gray, 1);
                    _disposer.Add(_myPen);
                }
                return _myPen;
            }
        }


        public  Brush _shadowBrush;
        /// <summary>
        /// Brush把计て絋﹚ミΩ
        /// 
        /// </summary>
        public  Brush ShadowBrush
        {
            get
            {
                if (_shadowBrush == null)
                {
                    _shadowBrush = new SolidBrush(Color.Gray);
                    _disposer.Add(_shadowBrush);
                }
                return _shadowBrush;
            }
        }

        public Brush _activeBrush;

        /// <summary>
        /// Brush把计て絋﹚ミΩ
        /// brush度ノ北兜Active
        /// </summary>
        public Brush ActiveBrush
        {
            get
            {
                if (_activeBrush == null)
                {
                    _activeBrush = new SolidBrush(Color.Red);
                    _disposer.Add(_activeBrush);
                }
                return _activeBrush;
            }
        }

        public  Color ActiveTextColor { get { return Color.White; } }
        public  Color InactiveTextColor { get { return Color.Black; } }

        public FontStyle FontStyle { get; set; }

        public  Brush _inactiveBrush;

        /// <summary>
        /// Brush把计て絋﹚ミΩ
        /// brush度ノ北兜Inactive
        /// </summary>
        public  Brush InActiveBrush
        {
            get
            {
                if (_inactiveBrush == null)
                {
                    _inactiveBrush = new SolidBrush(Color.White);
                    _disposer.Add(_inactiveBrush);
                }
                return _inactiveBrush;
            }
        }

    }
}