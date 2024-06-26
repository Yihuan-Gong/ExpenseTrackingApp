﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.ChartDataFactory
{
    public abstract class AChartDataFactory
    {
        protected DateTime start;
        protected DateTime end;
        protected ChartType chartType;
        protected IEnumerable<ExpenceDataType> groupByDataTypes;

        public AChartDataFactory(DateTime start, DateTime end, ChartType chartType, IEnumerable<ExpenceDataType> groupByDataTypes)
        {
            this.start = start;
            this.end = end;
            this.chartType = chartType;
            this.groupByDataTypes = groupByDataTypes;
        }

        public abstract object GetChartData();
    }
}
