using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WinF_MVP.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace WinF_MVP.Presenters
{
    internal class AddPresenter
    {
        private IAddView _addView;

        public AddPresenter(IAddView addView)
        {
            _addView = addView;

            _addView.SaveEvent += _addView_SaveEvent;
            _addView.CancelEvent += _addView_CancelEvent;
        }

        private bool ValidateName(string name)=> Regex.Match(name, "^[A-Z][a-zA-Z]*$").Success;
         
        
        private void _addView_SaveEvent(object? sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            if (!ValidateName(_addView.FirstName))
                sb.Append($"Invalid {nameof(_addView.FirstName)}\n");

            if (!ValidateName(_addView.LastName))
                sb.Append($"Invalid {nameof(_addView.LastName)}\n");

            if ((DateTime.Now.Year - _addView.BirthDate.Year)<15)
                sb.Append("Invalid Age (min age:15)\n");

            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _addView.DialogResult = DialogResult.OK;
        }

        private void _addView_CancelEvent(object? sender, EventArgs e) => _addView.DialogResult = DialogResult.Cancel;
    }
}
