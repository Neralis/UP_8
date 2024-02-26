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
            // �������������� ���������� ��� �������� �������� � ��������
            double commonValue = 0;
            int zIndex = -1;
            int aIndex = -1;

            // �������� �� ��������� ������� a
            for (int i = 0; i < a.Length; i++)
            {
                // ���� ������� �� ������� a ��������� � ��������� �� ������� z � ������ ������ �������� ������������ �������
                if (z.Contains(a[i]) && (zIndex == -1 || Array.IndexOf(z, a[i]) < zIndex))
                {
                    // ��������� �������� � �������
                    commonValue = a[i];
                    zIndex = Array.IndexOf(z, a[i]);
                    aIndex = i;
                }
            }

            // ������� ����������
            if (zIndex != -1)
            {
                label3.Text = $"������ ����� �������: {commonValue}, �������: z[{zIndex}], a[{aIndex}]";
            }
            else
            {
                label3.Text = "����� ��������� �� �������";
            }
        }


        //Tab2----------------------------------------------------------------------------------------------

        private void button2_Click(object sender, EventArgs e)
        {
            string[] inputStrings = textBox3.Text.Split(',');

            List<int> m = new List<int>();

            // ������� �������� ������ ������ � �������
            foreach (string inputString in inputStrings)
            {
                if (int.TryParse(inputString.Trim(), out int value))
                {
                    m.Add(value);
                }
                else
                {
                    MessageBox.Show($"������ ��� ������ �����: {inputString}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // ������� �� ������ � ������ ������
                }
            }

            // ������������ ������� p, ���������� �������� �������� ������� ������������� ��������� ������� m
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

            // ������� �������� ������ ������ � �������
            for (int i = 0; i < inputStrings.Length; i++)
            {
                if (int.TryParse(inputStrings[i].Trim(), out int value))
                {
                    k[i] = value;
                }
                else
                {
                    MessageBox.Show($"������ ��� ������ �����: {inputStrings[i]}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // ������� �� ������ � ������ ������
                }
            }

            // ������������ ��� ��������� k[i], k[i+1], ��� i = 0, 2, 4, 6, 8
            for (int i = 0; i < k.Length - 1; i += 2)
            {
                int temp = k[i];
                k[i] = k[i + 1];
                k[i + 1] = temp;
            }

            // ����� ����������� ������� � textBox6
            textBox6.Text = string.Join(", ", k);
        }
    }
}
