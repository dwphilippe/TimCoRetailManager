using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRMDataManager.Areas.HelpPage.ModelDescriptions;

namespace TRMDesktopUI.Library.Helpers
{
    public class ConfigHelper
    {
        public static decimal TaxPercentGet()
        {
            if (decimal.TryParse(ConfigurationManager.AppSettings["tax_percent"], out decimal taxPercent))
            {
                decimal minPercent = 0.99m;
                if (taxPercent < 50 && taxPercent.CompareTo(minPercent) > 0)
                {
                    return taxPercent;
                }
                else
                {
                    throw new ConfigurationErrorsException("Er is een ongeldig tax-percentage in het config-bestand gevonden !");
                }
            }
            else
            {
                throw new ConfigurationErrorsException("Er is een ongeldig tax-percentage in het config-bestand gevonden !");
            }
        }
    }
}
