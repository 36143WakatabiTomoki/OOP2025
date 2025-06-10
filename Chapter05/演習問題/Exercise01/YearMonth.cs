﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01
{
    public record YearMonth(int Year, int Month) {
        // 5.1.1

        // 5.1.2
        public bool Is21Century => Year >= 2001 && Year <= 2100;

        // 5.1.3
        public YearMonth AddOneMonth() {
            if (Month >= 12)
                return new YearMonth(Year + 1, 1);
            else
                return new YearMonth(Year, Month + 1);
        }

        // 5.1.4
        public override string ToString() => $"{Year}年{Month}月";
    }
}
