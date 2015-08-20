﻿using _1._7.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._7.Answers
{
    public interface IRotator
    {
        Matrix<Pixel> RotateCW(Matrix<Pixel> input);
        Matrix<Pixel> RotateCCW(Matrix<Pixel> input);
    }
}