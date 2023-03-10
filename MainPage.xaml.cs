using System;

namespace Week6;



    public partial class MainPage : ContentPage
    {
        string appDirectory = FileSystem.Current.AppDataDirectory;
        string fileName = "test.txt";
        List<string> contents = new();

        public MainPage()
        {
            InitializeComponent();
        }


        private async void OnCounterClicked(object sender, EventArgs e)
        {
            await SaveData();
            string content = await ReadFile();
            contents.Add(content);

            DataDisplay.ItemsSource = null;
            DataDisplay.ItemsSource = contents;
        }

        private async Task<string> ReadFile()
        {
            string text = "";
            using FileStream stream = File.Open(Path.Combine(appDirectory, fileName), FileMode.Open);
            using StreamReader sr = new StreamReader(stream);
        try
        {
            text = await sr.ReadToEndAsync();
            await Console.Out.WriteLineAsync(text);
        }
        catch (PathTooLongException ex) 
        {
            //Augment the path to be shorter
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);

        }
            return text;
        }

        private async Task SaveData()
        {
            using FileStream stream = File.Open(Path.Combine(appDirectory, fileName), FileMode.Create);

            using StreamWriter sr = new StreamWriter(stream);
            try
            {
                await sr.WriteLineAsync(DataEntry.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    private void ButtonRead_Clicked_1(object sender, EventArgs e)
    {
        Class1 obj = new();
        try
        {
            obj.ThrowsException(0);
        }
        catch (InvalidInputException ex) 
        {
            Console.WriteLine(ex.Message);
        }
    }

    private async void PopUp_Clicked(object sender, EventArgs e)
    {
        //bool result = await DisplayAlert("Ice Cream", "Would you like some? ", "yes", "no");
        //await DisplayAlert("answer", $"Are you having Ice Cream: " + result, result ? "Yay" : ":C");

        string answer = await DisplayActionSheet("Your Fav Social Media is?","Cancel", "None of the above", "Facebook", "Twitter", "Reddit", "Instagram");
        Choice.Text = answer;

    }
}


