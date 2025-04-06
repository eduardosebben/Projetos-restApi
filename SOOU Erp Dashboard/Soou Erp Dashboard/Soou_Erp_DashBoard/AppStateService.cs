using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soou_Erp_DashBoard
{
    public class AppStateService
    {
        public event Action<bool> ShowToggleButtonChanged;

        private bool showToggleButton;

        public bool ShowToggleButton
        {
            get => showToggleButton;
            set
            {
                if (showToggleButton != value)
                {
                    showToggleButton = value;
                    ShowToggleButtonChanged?.Invoke(showToggleButton);
                }
            }
        }
    }
}
