using FSK_BusinessObjects;
using FSK_Repositories;
using FSK_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FengShuiKoi
{
    /// <summary>
    /// Interaction logic for Compatibility.xaml
    /// </summary>
    public partial class Compatibility : Window
    {
        private readonly IKoiFishService koifishService;
        private readonly IElementService elementService;
        private readonly ITankService tankService;
        private readonly CompatibilityService compatibilityService;

        public Compatibility()
        {
            InitializeComponent();

            this.elementService = new ElementService();
            this.tankService = new TankService();
            this.koifishService = new KoiFishService();

            var elementRepo = new ElementRepo();
            var tankRepo = new TankRepo();
            this.compatibilityService = new CompatibilityService(elementRepo, tankRepo);

            LoadTankOptions();
            LoadFishOptions();
            LoadUserElementOptions();
        }

        private void LoadTankOptions()
        {
            var tanks = tankService.GetTanks();

            if (tanks == null || !tanks.Any())
            {
                MessageBox.Show("No tanks found in the database.");
                return;
            }

            TankComboBox.ItemsSource = tanks;
            TankComboBox.DisplayMemberPath = "TankId";
        }

        private void LoadFishOptions()
        {
            var fishElements = koifishService.GetKoiFishs();

            if (fishElements == null || !fishElements.Any())
            {
                MessageBox.Show("No fish found in the database.");
                return;
            }

            FishComboBox.ItemsSource = fishElements;
        }

        private void LoadUserElementOptions()
        {
            var userElement = elementService.GetElements();

            if (userElement == null || !userElement.Any())
            {
                MessageBox.Show("No elements found in the database.");
                return;
            }

            UserElementComboBox.ItemsSource = userElement;
            UserElementComboBox.DisplayMemberPath = "ElementName";  
            UserElementComboBox.SelectedValuePath = "ElementId"; 
        }

        private void TankComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TankComboBox.SelectedItem is Tank selectedTank)
            {
                MessageBox.Show($"Selected Tank:\nID: {selectedTank.TankId}\nShape: {selectedTank.Shape}\nElementId: {selectedTank.ElementId}", "Tank Information");
            }
        }

        private void FishComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedFish = FishComboBox.SelectedItems
        .Cast<KoiFish>()
        .Select(fish => fish.Name) 
        .Where(name => name != null)
        .ToList();

            if (!selectedFish.Any())
            {
                MessageBox.Show("Please select at least one fish.", "Selection Required", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                string selectedFishList = string.Join(", ", selectedFish);
                MessageBox.Show($"Selected Fish: {selectedFishList}", "Fish Selection");
            }
        }

        private void CalculateCompatibility_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (compatibilityService == null)
                {
                    MessageBox.Show("Compatibility service is not initialized.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                string selectedTank = TankComboBox.SelectedItem as string;
                var selectedFishElements = FishComboBox.Items.Cast<ComboBoxItem>()
                    .Where(item => item.IsSelected)
                    .Select(item => item.Content.ToString())
                    .ToHashSet();

                if (string.IsNullOrEmpty(selectedTank) || !selectedFishElements.Any())
                {
                    MessageBox.Show("Please select a tank and at least one fish.", "Input Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Convert selectedTank and selectedFishElements to int
                if (!int.TryParse(selectedTank, out int tankElementId))
                {
                    MessageBox.Show("Invalid tank selection. Please select a valid tank ID.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var fishElementIds = new HashSet<HashSet<int>>();
                foreach (var fishId in selectedFishElements)
                {
                    if (int.TryParse(fishId, out int fishElementId))
                    {
                        fishElementIds.Add(new HashSet<int> { fishElementId });
                    }
                    else
                    {
                        MessageBox.Show($"Invalid fish selection '{fishId}'. Please select valid fish IDs.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }

                // Create a request for compatibility scoring
                var compatibilityRequest = new CompatibilityRequest(); // Populate as required

                // Call CompatibilityScore with integer values
                int userElementId = UserElementComboBox.SelectedValue as int? ?? -1;

                if (userElementId == -1)
                {
                    MessageBox.Show("Please select an element.", "Input Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var response = compatibilityService.CompatibilityScore(userElementId, tankElementId, fishElementIds, compatibilityRequest);

                ResultTextBlock.Text = $"Fish Score: {response.FishCompatibilityScore}%, Tank Score: {response.TankCompatibilityScore}%, Final Score: {response.CalculateCompatibilityScore}%";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UserElementComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UserElementComboBox.SelectedValue is int selectedElementId)
            {
                MessageBox.Show($"Selected Element ID: {selectedElementId}", "Element Selection");
            }
        }
    }
}
