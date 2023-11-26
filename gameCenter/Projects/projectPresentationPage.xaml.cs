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
using System.Windows.Threading;

namespace gameCenter.Projects
{
    /// <summary>
    /// Interaction logic for projectPresentationPage.xaml
    /// </summary>
    public partial class projectPresentationPage : Window
    {
        private Window project;
        private Window? currentProject;
      
        public projectPresentationPage()
        {
            InitializeComponent();

            DispatcherTimer clock = new()
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            clock.Tick += ShowCurrentDate!;
            clock.Start();

        }
        private void ShowCurrentDate(object sender, EventArgs e)
        {
            DateLabel.Content = DateTime.UtcNow.ToString("dd/MM/yy HH:mm");
        }


        public void OnStart(string title, string projectDescription, ImageSource imageSoursce, Window project)
        {
            TitleLabel.Content = title;
            ProjectText.Text = projectDescription;
            ProjectImage.Source = imageSoursce;
            currentProject = project;
       
        }

      
        private void ProjectImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Close();
            currentProject!.ShowDialog();
            currentProject!.Close();
        }

        private void image_ReturnYoMain(object sender, MouseButtonEventArgs e)
        {
            Close();
           
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            Image image = (sender as Image)!;
            image.Opacity = 0.7;
       
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Image)!.Opacity = 1;
         
        }

    }
}
