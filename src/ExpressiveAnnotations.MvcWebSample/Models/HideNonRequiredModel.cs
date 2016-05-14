using ExpressiveAnnotations.Attributes;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ExpressiveAnnotations.MvcWebSample.Models {
    public class HideNonRequiredModel {
        public int[] Question1 { get; set; }

        [RequiredIf("ArrayContains(2, Question1)")]
        public int[] Question2 { get; set; }

        [RequiredIf("ArrayContains(1, Question2)")]
        public string Question3 { get; set; }

        //public int[] Question1Options => new[] { 1, 2, 3 };

        //public int[] Question2Options => new[] { 1, 2, 3 };

        public IEnumerable<SelectListItem> Question1Options => new[] {
            new SelectListItem {Text = "One", Value = "1"},
            new SelectListItem {Text = "*Two*", Value = "2"},
            new SelectListItem {Text = "Three", Value = "3"}
        };

        public IEnumerable<SelectListItem> Question1Selections = new List<SelectListItem>();

        public IEnumerable<SelectListItem> Question2Options => new[] {
            new SelectListItem {Text = "*One*", Value = "1"},
            new SelectListItem {Text = "Two", Value = "2"},
            new SelectListItem {Text = "Three", Value = "3"}
        };
    }
}