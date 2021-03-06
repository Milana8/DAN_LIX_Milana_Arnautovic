﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Zadatak_1
{
    /// <summary>
    /// Card names
    /// </summary>
    enum ButtonNames
    {
        one = 1,
        two,
        three,
        four,
        five,
        six,
        seven,
        eight,
        nine,
        ten,
        eleven,
        twelve,
        thirteen,
        fourteen,
        fifteen,
        sixteen
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        private List<String> _words = new List<string>();
        private List<Int32> _wordsCount = new List<int>();
        private List<String> _wordsValue = new List<string>();
        private List<Button> _buttons = new List<Button>();
        private Brush _default;
        private int _disabledButtons = 0;

        public MainWindow()
        {


            InitializeComponent();
            //adding symbols to the list

            _wordsValue.Add("A");
            _wordsValue.Add("B");
            _wordsValue.Add("C");
            _wordsValue.Add("D");
            _wordsValue.Add("E");
            _wordsValue.Add("F");
            _wordsValue.Add("G");
            _wordsValue.Add("H");
            InitializeSymbols();
            _default = one.Background;
        }



        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Content == "")
            {
                if (_buttons.Count < 2)
                {
                    OpenButton(sender);
                }
                else
                {
                    CloseButtons();
                }
            }
        }


        private void InitializeSymbols()
        {
            for (int i = 0; i < 16; i++)
            {
                _wordsCount.Add(2);
            }
            Random rnd = new Random(DateTime.Now.Second);
            for (int i = 0; i < 16; i++)
            {
                int buf;
                do
                {
                    buf = rnd.Next(0, 8);
                } while (_wordsCount[buf] == 0);
                _words.Add(_wordsValue[buf]);
                _wordsCount[buf]--;
            }
        }
        /// <summary>
        /// Start new game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            DoEnableButtons();
            _words.Clear();
            _wordsCount.Clear();
            _disabledButtons = 0;
            InitializeSymbols();

        }
        /// <summary>
        /// Game
        /// </summary>
        /// <param name="sender"></param>
        private void OpenButton(object sender)
        {

            String name = ((Button)sender).Name;
            ((Button)sender).Content = _words[((int)Enum.Parse(typeof(ButtonNames), name)) - 1];
            ((Button)sender).Background = Brushes.Green;
            _buttons.Add((Button)sender);
            if (_buttons.Count == 2)
            {
                if (_buttons[0].Content == _buttons[1].Content)
                {
                    foreach (var button in _buttons)
                    {
                        button.IsEnabled = false;
                        _disabledButtons++;
                    }
                    _buttons.Clear();
                    if (_disabledButtons == 16) //if all the fields are open, the game is over

                    {
                        MessageBox.Show("Congratulations! You won.", "Win", MessageBoxButton.OK, MessageBoxImage.Information);
                        DoEnableButtons();
                        _words.Clear();
                        _wordsCount.Clear();
                        _disabledButtons = 0;
                        InitializeSymbols();
                    }
                }


            }
        }

        /// <summary>
        ///  Closing tabs
        /// </summary>
        private void CloseButtons()
        {
            foreach (var button in _buttons)
            {
                button.Background = _default;
                button.Content = "";
            }
            _buttons.Clear();
        }

        private void DoEnableButtons()
        {
            one.IsEnabled = true;
            two.IsEnabled = true;
            three.IsEnabled = true;
            four.IsEnabled = true;
            five.IsEnabled = true;
            six.IsEnabled = true;
            seven.IsEnabled = true;
            eight.IsEnabled = true;
            nine.IsEnabled = true;
            ten.IsEnabled = true;
            eleven.IsEnabled = true;
            twelve.IsEnabled = true;
            thirteen.IsEnabled = true;
            fourteen.IsEnabled = true;
            fifteen.IsEnabled = true;
            sixteen.IsEnabled = true;
            one.Content = "";
            two.Content = "";
            three.Content = "";
            four.Content = "";
            five.Content = "";
            six.Content = "";
            seven.Content = "";
            eight.Content = "";
            nine.Content = "";
            ten.Content = "";
            eleven.Content = "";
            twelve.Content = "";
            thirteen.Content = "";
            fourteen.Content = "";
            fifteen.Content = "";
            sixteen.Content = "";
            one.Background = _default;
            two.Background = _default;
            three.Background = _default;
            four.Background = _default;
            five.Background = _default;
            six.Background = _default;
            seven.Background = _default;
            eight.Background = _default;
            nine.Background = _default;
            ten.Background = _default;
            eleven.Background = _default;
            twelve.Background = _default;
            thirteen.Background = _default;
            fourteen.Background = _default;
            fifteen.Background = _default;
            sixteen.Background = _default;
        }

    }
}

