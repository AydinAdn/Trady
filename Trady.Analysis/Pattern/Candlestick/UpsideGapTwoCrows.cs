﻿using System;
using System.Collections.Generic;
using Trady.Analysis.Infrastructure;
using Trady.Core;

namespace Trady.Analysis.Pattern.Candlestick
{
    /// <summary>
    /// Reference: http://stockcharts.com/school/doku.php?id=chart_school:chart_analysis:candlestick_pattern_dictionary
    /// </summary>
    public class UpsideGapTwoCrows<TInput, TOutput> : AnalyzableBase<TInput, (decimal Open, decimal High, decimal Low, decimal Close), bool?, TOutput>
    {
        public UpsideGapTwoCrows(IEnumerable<TInput> inputs, Func<TInput, (decimal Open, decimal High, decimal Low, decimal Close)> inputMapper) : base(inputs, inputMapper)
        {
        }

        protected override bool? ComputeByIndexImpl(IEnumerable<(decimal Open, decimal High, decimal Low, decimal Close)> mappedInputs, int index)
        {
            throw new NotImplementedException();
        }
    }

    public class UpsideGapTwoCrowsByTuple : UpsideGapTwoCrows<(decimal Open, decimal High, decimal Low, decimal Close), bool?>
    {
        public UpsideGapTwoCrowsByTuple(IEnumerable<(decimal Open, decimal High, decimal Low, decimal Close)> inputs) 
            : base(inputs, i => i)
        {
        }
    }

    public class UpsideGapTwoCrows : UpsideGapTwoCrows<Candle, AnalyzableTick<bool?>>
    {
        public UpsideGapTwoCrows(IEnumerable<Candle> inputs) 
            : base(inputs, i => (i.Open, i.High, i.Low, i.Close))
        {
        }
    }
}