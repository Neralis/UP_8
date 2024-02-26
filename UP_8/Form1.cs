using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace UP_8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //Tab1-------------------------------------------------------------------------------------------------------

        private void button1_Click(object sender, EventArgs e)
        {
            char[] separators = { ',' };

            double[] z = textBox1.Text.Split(separators)
                                       .Select(s => Double.Parse(s.Trim(), CultureInfo.InvariantCulture))
                                       .ToArray();

            double[] a = textBox2.Text.Split(separators)
                                       .Select(s => Double.Parse(s.Trim(), CultureInfo.InvariantCulture))
                                       .ToArray();

            FindCommonElements(z, a);
        }

        private void FindCommonElements(double[] z, double[] a)
        {
            // Инициализируем переменные для хранения значений и индексов
            double commonValue = 0;
            int zIndex = -1;
            int aIndex = -1;

            // Проходим по элементам массива a
            for (int i = 0; i < a.Length; i++)
            {
                // Если элемент из массива a совпадает с элементом из массива z и индекс меньше текущего минимального индекса
                if (z.Contains(a[i]) && (zIndex == -1 || Array.IndexOf(z, a[i]) < zIndex))
                {
                    // Обновляем значения и индексы
                    commonValue = a[i];
                    zIndex = Array.IndexOf(z, a[i]);
                    aIndex = i;
                }
            }

            // Выводим результаты
            if (zIndex != -1)
            {
                label3.Text = $"Первый общий элемент: {commonValue}, Индексы: z[{zIndex}], a[{aIndex}]";
            }
            else
            {
                label3.Text = "Общих элементов не найдено";
            }
        }


        //Tab2----------------------------------------------------------------------------------------------

        private void button2_Click(object sender, EventArgs e)
        {
            string[] inputStrings = textBox3.Text.Split(',');

            List<int> m = new List<int>();

            // Попытка парсинга каждой строки в массиве
            foreach (string inputString in inputStrings)
            {
                if (int.TryParse(inputString.Trim(), out int value))
                {
                    m.Add(value);
                }
                else
                {
                    MessageBox.Show($"Ошибка при чтении числа: {inputString}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Выходим из метода в случае ошибки
                }
            }

            // Формирование массива p, элементами которого являются индексы положительных элементов массива m
            List<int> p = new List<int>();
            for (int i = 0; i < m.Count; i++)
            {
                if (m[i] > 0)
                {
                    p.Add(i);
                }
            }
            textBox4.Text = string.Join(", ", p);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] inputStrings = textBox5.Text.Split(',');

            int[] k = new int[inputStrings.Length];

            // Попытка парсинга каждой строки в массиве
            for (int i = 0; i < inputStrings.Length; i++)
            {
                if (int.TryParse(inputStrings[i].Trim(), out int value))
                {
                    k[i] = value;
                }
                else
                {
                    MessageBox.Show($"Ошибка при чтении числа: {inputStrings[i]}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Выходим из метода в случае ошибки
                }
            }

            // Перестановка пар элементов k[i], k[i+1], где i = 0, 2, 4, 6, 8
            for (int i = 0; i < k.Length - 1; i += 2)
            {
                int temp = k[i];
                k[i] = k[i + 1];
                k[i + 1] = temp;
            }

            // Вывод полученного массива в textBox6
            textBox6.Text = string.Join(", ", k);
        }
    }
}
