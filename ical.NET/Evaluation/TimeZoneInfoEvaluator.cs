﻿using System;
using System.Collections.Generic;
using Ical.Net.Interfaces.Components;
using Ical.Net.Interfaces.DataTypes;

namespace Ical.Net.Evaluation
{
    public class TimeZoneInfoEvaluator : RecurringEvaluator
    {
        #region Protected Properties

        protected ITimeZoneInfo TimeZoneInfo
        {
            get { return Recurrable as ITimeZoneInfo; }
            set { Recurrable = value; }
        }

        #endregion

        #region Constructors

        public TimeZoneInfoEvaluator(ITimeZoneInfo tzi) : base(tzi) {}

        #endregion

        #region Overrides

        public override HashSet<IPeriod> Evaluate(IDateTime referenceDate, DateTime periodStart, DateTime periodEnd, bool includeReferenceDateInResults)
        {
            // Time zones must include an effective start date/time
            // and must provide an evaluator.
            if (TimeZoneInfo != null)
            {
                // Always include the reference date in the results
                var periods = base.Evaluate(referenceDate, periodStart, periodEnd, true);
                return periods;
            }

            return new HashSet<IPeriod>();
        }

        #endregion
    }
}