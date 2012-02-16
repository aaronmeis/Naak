﻿using System;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace Naak.HtmlRules.Impl
{
	public class AccessibilityRenderer
	{
	    public object Render(string html, IEnumerable<IHtmlRule> rules)
		{
            var accessibilityErrors = GetAccessibilityErrors(html, rules);

            return RenderHtml(accessibilityErrors);
		}

        public ValidationError[] GetAccessibilityErrors(string html, IEnumerable<IHtmlRule> rules)
        {
            var records = new List<ValidationError>();

            try
            {
                var document = BuildDocument(html);

                foreach (var htmlRule in rules)
                {
                    ValidationError[] currentRecords = htmlRule.ValidateHtml(document);

                    foreach (var record in currentRecords)
                    {
                        records.Add(record);
                    }
                }
            }
            catch (Exception exc)
            {
                records.Add(new ValidationError(exc.Message));
            }

            return records.ToArray();
        }

        private static HtmlDocument BuildDocument(string html)
        {
            var document = new HtmlDocument();
            document.LoadHtml(html);
            return document;
        }
        
        private static object RenderHtml(IEnumerable<ValidationError> records)
		{
		    return null;
		}
	}
}