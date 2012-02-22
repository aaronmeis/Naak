using System.Net.Mime;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Naak.HtmlRules.Default;

namespace Naak.UnitTests
{
	[TestFixture]
	public class ImagesDontHaveDuplicateAltTextTester : HtmlRuleTester
	{
		[Test]
		public void Identifies_images_tag_wtih_duplicate_alt_text()
		{
			var bodyHtml = new StringBuilder();
			bodyHtml.Append(@"<img id=""i1"" alt=""Unique Test"" />");
			bodyHtml.Append(@"<P/>");
			bodyHtml.Append(@"<img  alt=""Description"" id=""i2"" />");
			bodyHtml.Append(@"<img id=""i3""  alt=""Description""/>");
			bodyHtml.Append(@"<img id=""i4""  alt=""Description""/>");

			ExecuteTest(new ImagesDontHaveDuplicateAltText(), bodyHtml.ToString());

			Assert.That(ErrorCount, Is.EqualTo(2));
			Assert.That(ContainsError(@"Image has duplicate alt text: <img id=""i3"" alt=""Description"">"));
			Assert.That(ContainsError(@"Image has duplicate alt text: <img id=""i4"" alt=""Description"">"));
		}


	}
}