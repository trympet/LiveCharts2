﻿// The MIT License(MIT)

// Copyright(c) 2021 Alberto Rodriguez Orozco & LiveCharts Contributors

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using Avalonia.Media;
using LiveChartsCore.Drawing;
using LiveChartsCore.Drawing.Common;
using LiveChartsCore.Motion;

namespace LiveChartsCore.AvaloniaView.Drawing
{
    public class LineSegment : PathCommand, ILinePathSegment<StreamGeometryContext>
    {
        private readonly FloatMotionProperty xTransition;
        private readonly FloatMotionProperty yTransition;

        public LineSegment()
        {
            xTransition = RegisterMotionProperty(new FloatMotionProperty(nameof(X), 0f));
            yTransition = RegisterMotionProperty(new FloatMotionProperty(nameof(Y), 0f));
        }

        public float X { get => xTransition.GetMovement(this); set => xTransition.SetMovement(value, this); }
        public float Y { get => yTransition.GetMovement(this); set => yTransition.SetMovement(value, this); }

        public override void Execute(StreamGeometryContext path, long currentTime, Animatable pathGeometry)
        {
            SetCurrentTime(currentTime);
            path.LineTo(new Avalonia.Point(X, Y));
        }
    }
}
