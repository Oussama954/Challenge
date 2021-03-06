﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Challenge.Web.Validation
{
    public class CurrentDateAttribute : ValidationAttribute
    {
        public CurrentDateAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            if (value == null) return true;
            var dt = (DateTime)value;
            if (dt >= DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }
}