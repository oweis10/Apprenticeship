﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apprenticeship.Models
{
    public class SelectListItemComparer : IEqualityComparer<SelectListItem>
    {
        public bool Equals(SelectListItem x, SelectListItem y)
        {
            return x.Text == y.Text && x.Value == y.Value && x.Selected == true && y.Selected == false;
        }

        public int GetHashCode(SelectListItem item)
        {
            int hashText = item.Text == null ? 0 : item.Text.GetHashCode();
            int hashValue = item.Value == null ? 0 : item.Value.GetHashCode();
            return hashText ^ hashValue;
        }
    }
}
