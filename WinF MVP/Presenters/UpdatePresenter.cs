using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WinF_MVP.Interfaces;
using WinF_MVP.Views;

namespace WinF_MVP.Presenters
{
    internal class UpdatePresenter
    {
        private IUpdateView _updateView;

        private bool ValidateName(string name) => Regex.Match(name, "^[A-Z][a-zA-Z]*$").Success;
        public UpdatePresenter(IUpdateView updateView)
        {
            _updateView = updateView;

            _updateView.SaveEvent += _updateView_SaveEvent;
            _updateView.CancelEvent += _updateView_CancelEvent;
        }

        private void _updateView_SaveEvent(object? sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            if (!ValidateName(_updateView.FirstName))
                sb.Append($"Invalid {nameof(_updateView.FirstName)}\n");

            if (!ValidateName(_updateView.LastName))
                sb.Append($"Invalid {nameof(_updateView.LastName)}\n");

            if ((DateTime.Now.Year - _updateView.BirthDate.Year)<15)
                sb.Append("Invalid Age (min age:15)\n");

            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ((Form)_updateView).DialogResult = DialogResult.OK;
        }


        private void _updateView_CancelEvent(object? sender, EventArgs e) => ((Form)_updateView).DialogResult = DialogResult.Cancel;
    }
}
