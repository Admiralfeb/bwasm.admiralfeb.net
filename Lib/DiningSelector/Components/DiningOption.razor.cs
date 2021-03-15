using System;
using System.Collections.Generic;
using System.Linq;

namespace bwasm.admiralfeb.net.Lib.DiningSelector.Components
{
    public partial class DiningOption
    {
        private List<string> DiningOptions { get; set; }
        private List<string> DefaultOptions = new List<string> { "Firehouse Subs", "Qdoba", "Noodles and Company", "Freddy's Frozen Custard" };
        private string SelectedItem { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            ResetItems();
            SelectedItem = string.Empty;
            AlertService.addMessage(new Alert("Welcome to Dining Selector. You hungry?", Alerts.Primary));
        }

        private void SelectItem()
        {
            var random = new Random();
            var randValue = random.Next(0, DiningOptions.Count);
            SelectedItem = DiningOptions[randValue];
        }

        private void AddItem(string value)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Value cannot be blank");
                if (DiningOptions.Contains(value, StringComparer.OrdinalIgnoreCase))
                    throw new ArgumentException($"{value} already exists");
                DiningOptions.Add(value);
                DiningOptions.Sort();
            }
            catch (ArgumentException ex)
            {
                AlertService.addMessage(new Alert(ex.Message, Alerts.Danger));
            }
        }

        private void DeleteItem(string item)
        {
            DiningOptions.Remove(item);
        }

        private void ResetItems()
        {
            DiningOptions = DefaultOptions.ToList();
            DiningOptions.Sort();
        }
    }
}
