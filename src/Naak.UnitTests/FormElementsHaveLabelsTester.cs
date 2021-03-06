using System.Text;
using NUnit.Framework;
using Naak.HtmlRules.Default;

namespace Naak.UnitTests
{
	[TestFixture]
	public class FormElementsHaveLabelsTester
	{
		[Test]
		public void Correctly_identifies_form_fields_missing_labels()
		{
			var html = new StringBuilder();

			html.Append(@"<form>");
			html.Append(@"  <label for=""txtFirstName"">First Name</label>");
			html.Append(@"  <input type=""text"" id=""txtFirstName"" />");

			html.Append(@"  <label for=""txtMiddle"">First Name</label>");
			html.Append(@"  <input type=""text"" id=""txtMiddleName"" />");

			html.Append(@"  <label>Last Name</label>");
			html.Append(@"  <input type=""text"" id=""txtLastName"" />");

			html.Append(@"  <label for=""txtPassword"">Password</label>");
			html.Append(@"  <input type=""text"" id=""txtPassword"" />");

			html.Append(@"  <label for=""txtRetype"">Retype Password</label>");
			html.Append(@"  <input type=""password"" id=""txtRetypePassword"" />");

			html.Append(@"  <label for=""chkOption1"">Option 1</label>");
			html.Append(@"  <input type=""checkbox"" id=""chkOption1"" />");

			html.Append(@"  <label for=""chkOption"">Option 2</label>");
			html.Append(@"  <input type=""checkbox"" id=""chkOption2"" />");

			html.Append(@"  <label for=""ddlStatus1"">Status 1</label>");
			html.Append(@"  <select id=""ddlStatus1"" />");

			html.Append(@"  <label for=""ddlStatus"">Status 2</label>");
			html.Append(@"  <select id=""ddlStatus2"" />");

			html.Append(@"  <label for=""txtArea1"">Area 1</label>");
			html.Append(@"  <textarea id=""txtArea1"" />");

			html.Append(@"  <label for=""txtArea"">Area 2</label>");
			html.Append(@"  <textarea id=""txtArea2"" />");
			html.Append(@"</form>");

			var errors = new FormElementsHaveLabels().ValidateHtml(html);
		    
		    Assert.That(errors.Length, Is.EqualTo(6));

		    Assert.That(errors[0].Message.Contains("Textbox missing corresponding label"));
		    Assert.That(errors[0].Message.Contains(@"id=""txtMiddleName"""));

            Assert.That(errors[1].Message.Contains("Textbox missing corresponding label"));
            Assert.That(errors[1].Message.Contains(@"id=""txtLastName"""));

            Assert.That(errors[2].Message.Contains("Password textbox missing corresponding label"));
            Assert.That(errors[2].Message.Contains(@"id=""txtRetypePassword"""));

            Assert.That(errors[3].Message.Contains("Checkbox missing corresponding label"));
            Assert.That(errors[3].Message.Contains(@"id=""chkOption2"""));

            Assert.That(errors[4].Message.Contains("Select list missing corresponding label"));
            Assert.That(errors[4].Message.Contains(@"id=""ddlStatus2"""));

            Assert.That(errors[5].Message.Contains("Text area missing corresponding label"));
            Assert.That(errors[5].Message.Contains(@"id=""txtArea2"""));
	    }
	}
}